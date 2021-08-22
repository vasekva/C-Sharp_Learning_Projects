using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Interfaces;
using CarShop.Data.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddTransient<IManageCars, MockCars>(); // позволяет подключить класс и интерфейс, который реализуется этим классом
            services.AddTransient<ICarsCategory, MockCategory>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
