using System;
using System.Linq;
using Autofac;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Wolf.Extensions.AutomationConfiguration;
using Wolf.Extensions.DataBase;
using Wolf.Extensions.DataBase.MySql;
using Wolf.Infrastructure.Core.Extensions.Common;
using Wolf.ManagerService.Application.Behaviors;
using Wolf.ManagerService.Domain.Repository;

namespace Wolf.ManagerService
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        ///
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            Domain.StartUp.Run(services);
            services
                .AddMediatR(typeof(Startup))
                .AddAutoConfig(this._configuration);
            services.AddDbContext(option => { option.UseMysqlDbContext<ManagerDbContext>(); });
            Wolf.DependencyInjection.ServiceCollectionExtensions.AddAutoInject(services,"wolf");
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            Type[] mediator = TypeFinderCommon.TypeFinderOfClass(assemblies, typeof(IMediator)).ToArray();
            Type[] validators = TypeFinderCommon.TypeFinderOfClass(assemblies, typeof(IValidator<>)).ToArray();
            Type[] handler = TypeFinderCommon.TypeFinderOfClass(assemblies, typeof(IRequestHandler<,>))
                .ToArray();
            builder.RegisterTypes(mediator).AsImplementedInterfaces();
            builder.RegisterTypes(validators).AsImplementedInterfaces();
            builder.RegisterTypes(handler).AsImplementedInterfaces();
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return componentContext.TryResolve(t, out o) ? o : null;
                };
            });

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>)); //校验
            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>)); //事务
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "manager/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
