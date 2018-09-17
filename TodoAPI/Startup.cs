using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using TodoAPI.Models;

namespace TodoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info {
                    Title = "Todo API",
                    Version = "v1",
                    Description = "Rest API for a todo application",
                    Contact = new Contact {
                        Name = "Samuel Alves",
                        Url = "https://www.github.com/SamuelIGT"
                    }
                });
                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");

                c.IncludeXmlComments(xmlDocPath);
            });

            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TODO API");
            });

            app.UseDefaultFiles(); //This will automatically serve html file named default.html, default.htm, index.html or index.htm on the http request http://localhost:<port>
            app.UseStaticFiles(); //This will serve the
            app.UseMvc();
        }
    }
}
