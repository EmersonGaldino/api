using galdino.funcional.application_2.Service.Base.AppServicecBase;
using galdino.funcional.data.persistence.Repository.Base;
using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.core.Interface.Repository.User;
using galdino.funcional.domain.core.Interface.Service.User;
using galdino.funcional.domain.core.Service.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace galdino.funcional.api.Dependency
{
    public class DependencyInjectionConfiguration
	{
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            //AppService
            RegistrarInterfaces(services, typeof(AppServiceBase<UserDomain, IUserService, IUserRepository>), "Service", "AppService");

            //Service
            RegistrarInterfaces(services, typeof(ServiceBase<UserDomain, IUserRepository>), "Service", "Service");

            //Repositorios
            RegistrarInterfaces(services, typeof(RepositoryBase<UserDomain>), "Repository", "Repository");

         
        }
        private static void RegistrarInterfaces(IServiceCollection services, Type typeBase, string containsInNamespace, string sulfix)
        {
            var types = typeBase
                .Assembly
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                               type.Namespace.Contains(containsInNamespace) &&
                               type.Name.EndsWith(sulfix) &&
                               !type.IsGenericType &&
                               type.IsClass &&
                               type.GetInterfaces().Any());

            foreach (var type in types)
            {
                var interfaceType = type
                    .GetInterfaces()?
                    .FirstOrDefault(t => t.Name == $"I{type.Name}");
                if (interfaceType == null)
                {
                    continue;
                }
                services.AddScoped(interfaceType, type);
            }
        }
    }
}
