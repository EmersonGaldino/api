using galdino.funcional.api.Configurations;
using galdino.funcional.api.Dependency;
using galdino.funcional.api.Filters.Error;
using galdino.funcional.api.Filters.Performace;
using galdino.funcional.api.Filters.Security;
using galdino.funcional.api.Mapper;
using galdino.funcional.data.persistence.Uow.Connections;
using galdino.funcional.domain.shared.Configurations.Application;
using galdino.funcional.domain.shared.Interfaces.Connections;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace galdino.funcional.api
{
    public class Startup
	{
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();



            services.AddScoped<IConnectionFuncional, UnitOfWorkFuncional>(x =>
                new UnitOfWorkFuncional(Configuration.GetSection("Configuracoes").GetSection("Connection-Funcional").Value));



            services.Configure<ApplicationConfiguration>(Configuration.GetSection("Aplicacao"));
            services.AddTransient<PerformaceFilters>();
            services.AddTransient<SecurityFilter>();

            

            AuthConfiguration.Register(services, Configuration);
            AutoMapperConfiguration.Register(services, Configuration);
            DependencyInjectionConfiguration.Register(services, Configuration);


            services.AddMvc(options =>
            {
                options.Filters.AddService<PerformaceFilters>();
                options.Filters.AddService<SecurityFilter>();
                options.Filters.Add(typeof(ErrorFilters));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            SwaggerApiVersioningConfiguration.Register(services);

            var corsBuilder = new CorsPolicyBuilder()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", $"v1.0");


                c.DocumentTitle = "Emerson Galdino - Funcional";
                c.RoutePrefix = string.Empty;
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
            });

            app.UseAuthentication();

            app.UseMvc();

            app.UseCors("SiteCorsPolicy");           

        }
    }
}
