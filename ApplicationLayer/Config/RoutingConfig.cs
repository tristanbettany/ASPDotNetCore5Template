using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ApplicationLayer.Config
{
    public static class RoutingConfig
    {
        public static void Apply(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IConfiguration configuration
        ) {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "user",
                    pattern: "{controller=User}/{action=SignedOut}/{id?}"
                );

                endpoints.MapRazorPages();
            });
        }
    }
}
