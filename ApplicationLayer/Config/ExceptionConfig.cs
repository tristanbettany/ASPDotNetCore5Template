using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApplicationLayer.Config
{
    public static class ExceptionConfig
    {
        public static void Apply(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IConfiguration configuration
        ) {
            if (env.IsDevelopment() == true)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(configuration.GetValue<string>("ExceptionUri"));
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Exception/Code/{0}");
        }
    }
}
