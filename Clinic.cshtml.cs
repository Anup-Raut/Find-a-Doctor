using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorApp.Pages.Models;

namespace MyRazorApp.Areas.Doctor.Pages
{
  public class ClinicModel : ProfileBase
  {
    public ClinicModel(ProjectContext ctx) : base(ctx)
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
      // from the posted form
      String AreaPIN = Doctor.ClinicAreaPIN;

      if (String.IsNullOrEmpty(AreaPIN))
      {
        Message = "PIN is required. Nothing updated.";

        return RedirectToPage();
      }

      var doctor = await QueryDoctorFromDatabase();

      doctor.ClinicAreaPIN = AreaPIN;
      doctor.ClinicAddress = Doctor.ClinicAddress;

      await AddOrUpdate(doctor);

      // take the user to login page
      return RedirectToPage();

    }
  }
}
