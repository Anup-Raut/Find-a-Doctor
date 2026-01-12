using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorApp.Pages.Models;

namespace MyRazorApp.Areas.Patient.Pages
{
    [BindProperties]
    public class SearchModel : PageModel
    {
        protected readonly ProjectContext _ctx;

        public SearchModel(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        // [BindProperty] attribute applied at class above
        public String Specialization { get; set; }

        // [BindProperty] attribute applied at class above
        public String CityCode { get; set; }

        public IList<DoctorProfile> Doctors { get; set; }

        public IActionResult OnGetMakePay(int? doctorID)
        {
            // user is taken to paypal and now returns
            // with a payment ID

            // say, this is through a webhook from the paypal
            return RedirectToPage("Consultation", "PayPal", new { Area = "Patient", id = doctorID, paid = 500, txnID = "PayPal-" + DateTime.Now.Ticks.ToString().Substring(6), salt = "skey" });

        }

        public void OnPostAsync()
        {
            Doctors = _ctx.Doctors
            .Where(doc => (doc.SpecializationCode == Specialization) && (doc.ClinicAreaPIN == CityCode))
            .ToList();

            return;
        }
    }
}
