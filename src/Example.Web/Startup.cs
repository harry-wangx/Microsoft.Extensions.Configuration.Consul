using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Example.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
        }


        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var builder = new ConfigurationBuilder()
                    .AddConsul(options=> {
                        options.Address = new Uri("https://demo.consul.io");
                        options.Datacenter = "nyc3";
                        //consul中的key是区分大小写的,所以这里的prefix要注意大小写
                        options.Prefix = null;
                    });
                IConfigurationRoot configuration = builder.Build();

                await context.Response.WriteAsync(configuration["global:time"]);
            });
        }
    }
}
