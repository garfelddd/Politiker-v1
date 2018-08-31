using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kernel.CQRS;
using Politiker.Infrastructure;
using Politiker.Modules;
using Politiker.Application.Modules;

namespace Politiker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //Connection string
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //Angular path
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //DbContext
            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Main")));

            //AutoMapper Configuration
            AutoMapperConfiguration.Register(Politiker.Core.Emitter.MapperClasses())
               .Initialize();
            
            //Autofac
            var builder = new ContainerBuilder();
            //Politiker.Application Autofac Module
            builder.RegisterModule(new ApplicationDiModule());
            //CQRS Dispatcher
            builder.RegisterType<Dispatcher>().AsSelf().InstancePerLifetimeScope();
            builder.Register<IServiceProvider>(c =>
            {
                return services.BuildServiceProvider();
            })
            .SingleInstance();
            builder.Populate(services);
            var container = builder.Build();


            return new AutofacServiceProvider(container);

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
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
