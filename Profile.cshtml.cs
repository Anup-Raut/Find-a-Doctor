using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Pages.Models;

namespace MyRazorApp.Areas.Patient.Pages
{
  public class ProfileBase : PageModel
  {
    protected readonly ProjectContext _ctx;

    // constructor injection
    protected ProfileBase(ProjectContext ctx)
    {
      _ctx = ctx;
    }

    [BindProperty]
    public PatientProfile Patient { get; set; }

    // a flag to track if the record already existed
    protected bool IsRecordNew;
    protected async Task<PatientProfile> QueryPatientFromDatabase()
    {
      String EMailOfPatient = User.FindFirst(ClaimTypes.Email).Value;

      var patient = await _ctx.Patients.FirstOrDefaultAsync(x => x.PatientEMail == EMailOfPatient);

      // null if record not found
      if (null == patient)
      {
        patient = new PatientProfile() { PatientEMail = EMailOfPatient };

        IsRecordNew = true;
      }
      else
      {
        IsRecordNew = false;
      }

      return patient;
    }

    [TempData]
    public String Message { get; set; }

    protected async Task AddOrUpdate(PatientProfile patient)
    {
      if (IsRecordNew)
      {
        _ctx.Add(patient);
      }
      else
      {
        _ctx.Update(patient);
      }

      // will be replaced if failure
      Message = "Updated successfully!";

      try
      {
        await _ctx.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        Message = "Fatal error. Retry.";
      }
    }

    public async Task OnGet()
    {
      Patient = await QueryPatientFromDatabase();
    }
  }

  public class ProfileModel : ProfileBase
  {
    public ProfileModel(ProjectContext ctx) : base(ctx)
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
      // from the posted form
      String NameOfPatient = Patient.Name;

      if (String.IsNullOrEmpty(NameOfPatient))
      {
        Message = "Name is required. Nothing updated.";

        return RedirectToPage();
      }

      var patient = await QueryPatientFromDatabase();

      patient.Name = NameOfPatient;
      patient.Phone = Patient.Phone;

      await AddOrUpdate(patient);

      // take the user to login page
      return RedirectToPage();

    }
  }
}
