using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QLVatLieuXayDung22.IService;
using QLVatLieuXayDung22.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLVatLieuXayDung22
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
            services.AddControllers();
            services.AddScoped<IUserSvc, Svc>();

            services.AddVersionedApiExplorer(c=>
            {
                c.GroupNameFormat = "'v'VVV";
                c.SubstituteApiVersionInUrl = true;
                c.AssumeDefaultVersionWhenUnspecified = true;
                c.DefaultApiVersion = new ApiVersion(1, 0);
               
            });

            services.AddApiVersioning(c =>
            {
                c.ReportApiVersions = true;
                c.AssumeDefaultVersionWhenUnspecified = true;
                c.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API v1.0",
                    Version = "v1",
                    Description = "Swashbuckle",
                });
                c.AddSecurityDefinition("", new OpenApiSecurityScheme
                {

                    Name = "Authorization",
                    Type = SecuritySchemeType.Http, Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "QL Vat Lieu Xay Dung"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Basic",

                        }
                    },
                    new string []{}
                    }
                });
            });

            services.AddAuthentication("Authentication")
                .AddScheme<AuthenticationSchemeOptions, Authen>
                ("Authentication", null);

            services.AddControllers();
            services.AddRouting();


            #region -- Swagger --  
            var inf1 = new OpenApiInfo
            {
                Title = "API v1.0",
                Version = "v1",
                Description = "Swashbuckle",
                TermsOfService = new Uri("http://appointvn.com"),
                Contact = new OpenApiContact
                {
                    Name = "Thao Hien",
                    Email = "trucly240302@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                }
            };
            var inf2 = new OpenApiInfo
            {
                Title = "API v2.0",
                Version = "v2",
                Description = "Swashbuckle",
                TermsOfService = new Uri("http://appointvn.com"),
                Contact = new OpenApiContact
                {
                    Name = "Thao Hien",
                    Email = "trucly240302@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                }
            };

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region -- Swagger --
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1.0");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API v2.0");
            });
            #endregion
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Svc");
            //});

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
