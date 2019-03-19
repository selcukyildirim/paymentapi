using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Api.Data;
using Payment.Api.Data.Garanti;
using Payment.Api.Data.YapiKredi;
using Payment.Api.Services;
using Payment.Api.Services.Implementation;
using Swashbuckle.AspNetCore.Swagger;

namespace Payment.Api
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
            services.AddScoped<IPaymentProcess, GarantiCreditCardPayment>();
            services.AddScoped<IPaymentProcess, YapiKrediCreditCardPayment>();
            services.AddScoped<IPaymentProcess, Garanti3DPayment>();
            services.AddScoped<IPaymentProcess, YapiKredi3DPayment>();
            services.AddScoped<IPayment3DProcess, Garanti3DPayment>();
            services.AddScoped<IPayment3DProcess, YapiKredi3DPayment>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Exaple.PaymentApi", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
                c.DescribeAllEnumsAsStrings();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example.PaymentApi");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
