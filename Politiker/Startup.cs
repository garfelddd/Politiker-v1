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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Politiker.Core.Engine;
using FluentValidation.AspNetCore;
using Politiker.Filters;
using Newtonsoft.Json.Serialization;

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
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            //Turning off automatic validation in api controller
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });



            //Connection string
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //JWT section in appsettings.json
            var jwtConfig = config.GetSection("JWT");
            var jwtKey = jwtConfig["SecretKey"];
            var issuerSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var jwtOptions = new JwtOptions
            {
                Key = jwtKey,
                SigningCredentials = new SigningCredentials(issuerSigninKey, SecurityAlgorithms.HmacSha256),
                Expires = 45
            };
            //services.AddSingleton(jwtOptions);
            //JWT token parameters
            var tokenParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["SecretKey"])),
                ValidateIssuerSigningKey = true
                //ValidIssuer = domain
            };

            //IoC of params
            //services.AddSingleton<>();

            //Auth
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.TokenValidationParameters = tokenParams;
            });

            //Auth services builder
            

            //Angular path
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            
            //DbContext
            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Main"), x => x.MigrationsAssembly("Politiker"))
                );
            

            //AutoMapper Configuration
            AutoMapperConfiguration.Register(Politiker.Core.Emitter.MapperClasses())
               .Initialize();
            
            //Autofac
            var builder = new ContainerBuilder();
            //Politiker.Application Autofac Module
            builder.RegisterModule(new ApplicationDiModule());
            //CQRS Dispatcher
            builder.RegisterType<Dispatcher>().AsSelf().InstancePerLifetimeScope();
            //Service Provider
            var serviceProvider = services.BuildServiceProvider();
            //JWT Options instance
            builder.RegisterInstance(jwtOptions).ExternallyOwned();
            //Automatic migrations
            var context = serviceProvider.GetService<MainContext>();
            //context.Database.Migrate();
            context.Database.EnsureCreated();
            builder.Register<IServiceProvider>(c =>
            {
                return serviceProvider;
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

            app.UseAuthentication();

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
