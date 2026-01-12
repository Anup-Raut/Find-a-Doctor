using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyRazorApp.Areas.Patient.Pages
{
  public class IndexModel : PageModel
  {
    readonly ProjectContext _ctx;

    public IndexModel(ProjectContext ctx)
    {
      _ctx = ctx;
    }

    public IList<Consultation> Consultations { get; set; }

    public async Task OnGet()
    {
      String patientEMail = User.FindFirst(ClaimTypes.Email).Value;

      Consultations = await _ctx.Consultations
        .Include(i => i.Doctor)
        .Where(p => p.Patient.PatientEMail == patientEMail)
        .OrderBy(m => m.DoctorResponse)
        .ThenByDescending(d => d.ConsultationDate)
        .ToListAsync();
    }
  }
}
