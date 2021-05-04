using DTIFunctions.Interfaces;
using DTIFunctions.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(DTIFunctions.Startup))]
namespace DTIFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            services.AddScoped<IGreeter, SimpleGreeter>();

        }
    }
}
