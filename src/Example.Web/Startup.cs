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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                //consul中的key是区分大小写的,所以这里的prefix要注意大小写
                var builder = new ConfigurationBuilder()
                    .AddConsul(prefix:"Config");
                IConfigurationRoot configuration = builder.Build();

                await context.Response.WriteAsync(configuration["aa"]+Environment.NewLine+ configuration["order:server1"]);
            });
        }
    }
}
