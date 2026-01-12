using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorApp.Pages.Models;

namespace MyRazorApp.Areas.Doctor.Pages
{
  public class FeesModel : ProfileBase
  {
    public FeesModel(ProjectContext ctx) : base(ctx)
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
      // from the posted form
      Int32 FeesOfDoctor = Doctor.Fees;

      if (FeesOfDoctor <= 0)
      {
        Message = "Fees required. Nothing updated.";

        return RedirectToPage();
      }

      String notes = Doctor.FeesNotes;

      var doctor = await QueryDoctorFromDatabase();

      doctor.Fees = FeesOfDoctor;

      doctor.FeesNotes = notes;

      await AddOrUpdate (doctor);

      // take the user to login page
      return RedirectToPage();

    }
  }
}
