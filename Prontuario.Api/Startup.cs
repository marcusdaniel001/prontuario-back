using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prontuario.Service.Extensions;

namespace Prontuario.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <inheritdoc />
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(_ => Configuration);
            services.ApiDependencias();

            services.Configure<GzipCompressionProviderOptions>(options =>
                options.Level = CompressionLevel.Optimal
            );
            services.AddResponseCompression();
            services.AddResponseCaching(options =>
            {
                options.UseCaseSensitivePaths = true;
                options.MaximumBodySize = 1024;
            });

            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                    UnicodeRanges.CjkUnifiedIdeographs }));
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
