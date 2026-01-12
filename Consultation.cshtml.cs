using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Pages.Models;

namespace MyRazorApp.Areas.Patient.Pages
{
    public class ConsultationModel : PageModel
    {
        private readonly ProjectContext _ctx;

        public ConsultationModel(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Consultation Consultation { get; set; }

        public async Task OnGetPayPalAsync(int? id, int? paid, String txnID, String salt)
        {
            var doctor = _ctx.Doctors.Find(id);

            // verify salt and paid amount with doctor.Fees
            // redirect elsewhere on failure

            // assuming success...

            String patientEMail = User.FindFirst(ClaimTypes.Email).Value;

            PatientProfile patient = await _ctx.Patients.FirstOrDefaultAsync(x => x.PatientEMail == patientEMail);

            if (null == patient)
            {
                patient = new PatientProfile() { PatientEMail = patientEMail };
            }

            Consultation = new Consultation()
            {
                Doctor = doctor,
                DoctorResponse = "",
                FeesPaid = (paid ?? 0),
                FeesTXN = txnID,
                Patient = patient,
                PatientMessage = "",
                ConsultationDate = DateTime.Now
            };

            _ctx.Consultations.Add(Consultation);

            await _ctx.SaveChangesAsync();
        }

        public async Task OnGetAsync(int? id)
        {
            Consultation = await _ctx.Consultations
            .Include(k => k.Doctor)
            .Include(p => p.Patient)
            .FirstOrDefaultAsync(k => k.ID == id);
        }

        public async Task<IActionResult> OnPostAsync(IFormFile fileReport)
        {
            // the message typed by the patient
            String patientMessage = Consultation.PatientMessage;

            byte[] fileBytes = null;

            if (
            (null != fileReport)
            &&
            (fileReport.Length < 1024000)
            &&
            ("application/pdf".Equals(fileReport.ContentType))
            )
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await fileReport.CopyToAsync(ms);

                    fileBytes = ms.ToArray();
                }
            }

            // use the ID to query the consultation
            var consultation = await _ctx.Consultations.FindAsync(Consultation.ID);

            // update patient message 
            consultation.PatientMessage = patientMessage;

            if (null != fileBytes)
            {
                consultation.PatientUpload = fileBytes;
            }

            _ctx.Consultations.Update(consultation);

            await _ctx.SaveChangesAsync();

            // redirect to consultations page
            return RedirectToPage("Index");
        }

        public async Task<FileResult> OnGetDownloadReport(int? id)
        {
            var consultation = await _ctx.Consultations.FindAsync(id);

            // compare customer email with IPrincipal EMail
            // to prevent download of someone else's reports

            return File(consultation.PatientUpload, "application/pdf", "rep.pdf");
        }
    }
}
