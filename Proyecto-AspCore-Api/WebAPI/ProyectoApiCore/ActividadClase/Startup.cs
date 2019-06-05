using System;
using System.IO;
using System.Reflection;
using Datos.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;


namespace ActividadClase
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
            services.AddDbContext<DbContextDatos>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ConexionDatos")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new Info
                    {
                        Version = "v1.0.0",
                        Title = "Api Clone de Trello",
                        Description = "APIs para la aplicación demo de Trello",
                        TermsOfService = "https://udistrital.edu.co",
                        Contact = new Contact()
                        {
                            Name = "Breitner Enrique González Angarita, Juan David Pineda Hernández, Andrei Ladino",
                            Email = "breinergonza@gmail.com",
                            Url = "www.breinergonza.net"
                        },
                        License = new License()
                        {
                            Name = "Licencia de usuario",
                            Url = "www.google.com"
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API");
            });

            app.UseMvc();
        }
    }
}
