using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherService.API;
using WeatherService.BusinessObjects;
using WeatherService.BusinessObjects.Interface;

namespace WeatherService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
            services.AddTransient<IFileManager, FileManager>();
            services.AddHttpClient<IGetWeatherDetailManager, GetWeatherDetailManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseMiddleWare();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
