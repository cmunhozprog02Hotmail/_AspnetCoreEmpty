using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using AspnetCoreEmpty.Services;

namespace AspnetCoreEmpty
{
    public class Startup
    {
        // Udar o método IConfiguration
        public IConfiguration _config { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IMensagemService, TextoMensagemService>();
            services.AddSingleton(provider => _config);
            services.AddSingleton<IMensagemService, ConfigurationMensagemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMensagemService msg)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                //app.UseExceptionHandler();
                app.UseStatusCodePages();
            }
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                /*var mensagem = _config["Mensagem"];
                var conexao = _config["ConnectionStrings:DefaultConnection"];

                await context.Response.WriteAsync(mensagem);
                await context.Response.WriteAsync(conexao);*/
                await context.Response.WriteAsync(msg.GetMensagem());

            });

        }
    }
}
