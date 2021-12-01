using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
using TrainingManagementRestAPI.Repository;

namespace TrainingManagementRestAPI
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
            services.AddDbContext<TrainingAcademyDBContext>(
               item => item.UseSqlServer(Configuration.GetConnectionString("ConStr"))
               );
            
            services.AddScoped<ILogin, Login>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ICourseEnquiryRepository, CourseEnquiryRepository>();
            services.AddScoped<IResourceEnquiryRepository, ResourceEnquiryRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<ISalesPipelineRepository, SalesPipelineRepository>();

            //jwt

            //register a JWT authentication schema
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    }
    );



            services.AddMvc();



            services.AddControllers().AddNewtonsoftJson(

                options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                }
                );

            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200", "https://b674-103-151-188-91.ngrok.io")
            .AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}