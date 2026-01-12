using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRazorApp.Pages.Models;

namespace MyRazorApp
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // make an arrangement for DependencyInjection 
      // of ProductContext instance. the database is 
      // created in the root directory of your project 
      // alternately create a folder, say, DBase and then 
      // specify the path as DBase/mydb.db 
      services.AddDbContext<ProjectContext>(

      opt => opt.UseSqlite(@"Data Source=Database/dbProject.db")

      );

      // Step 1: Add an authorization policy
      services.AddAuthorization(opt =>
      {
        // one policy for role "doctor"
        opt.AddPolicy("pdoctor",
          policy => { policy.RequireRole("Doctor"); });

        // another policy for role "patient"
        opt.AddPolicy("ppatient",
          policy => { policy.RequireRole("Patient"); });
      });


      // Step 2: Add policy to the entire folder
      services.AddRazorPages(
        opt =>
        {
          opt.Conventions.AuthorizeAreaFolder("doctor", "/", "pdoctor");

          opt.Conventions.AuthorizeAreaFolder("patient", "/", "ppatient");
        }
      );

      // Step 3: specify access deinied and login pages
      services
          .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(options =>
            {
              options.LoginPath = "/Login";

              options.AccessDeniedPath = "/Login";

            }
          );

            services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseCookiePolicy(new CookiePolicyOptions()
      {
        // this setting breaks OAuth2 and other cross-origin
        // authentication schemes, it elevates the 
        // level of cookie security for other types of apps
        MinimumSameSitePolicy = SameSiteMode.Strict
      });

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
          endpoints.MapControllers();
      });
    }
  }
}
