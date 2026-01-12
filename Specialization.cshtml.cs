using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRazorApp.Pages.Models;

namespace MyRazorApp.Areas.Doctor.Pages
{
  public class SpecializationModel : ProfileBase
  {
    public SpecializationModel(ProjectContext ctx) : base(ctx)
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
      // from the posted form
      String SpecializationOfDoctor = Doctor.SpecializationCode;

      if (String.IsNullOrEmpty(SpecializationOfDoctor))
      {
        Message = "Specialization is required. Nothing updated.";

        return RedirectToPage();
      }

      var doctor = await QueryDoctorFromDatabase();

      doctor.SpecializationCode = SpecializationOfDoctor;
      doctor.SpecializationNotes = Doctor.SpecializationNotes;

      await AddOrUpdate(doctor);

      // take the user to login page
      return RedirectToPage();

    }
  }
}
