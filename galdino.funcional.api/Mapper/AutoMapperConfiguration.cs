using AutoMapper;
using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.utils.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace galdino.funcional.api.Mapper
{
    public class AutoMapperConfiguration
	{
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                CreateMap(mc);
                mc.AddProfile<CustomMappingProfile>();
                mc.AddProfile<DomainToModelViewProfile>();
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        private static void CreateMap(IMapperConfigurationExpression mc)
        {
            //mapeamento das viewModels tipadas
            typeof(IModelView<>).Assembly.GetTypes()?.ToList().Where(vm =>
                    vm.IsAssignableToGenericType(typeof(IModelView<>)) && !vm.IsAbstract && !vm.IsInterface
                )
                .Where(vm =>
                    !JaMapeadoNoProfile(mc, vm.GetInterface(typeof(IModelView<>).Name).GetGenericArguments()[0], vm)
                    )
                .ToList()
                .ForEach(vm =>
                {
                    mc.CreateMap(vm.GetInterface(typeof(IModelView<>).Name).GetGenericArguments()[0], vm);
                });
            //mapeamento das viewModels tipadas
            typeof(IViewModel<>).Assembly.GetTypes()?.ToList().Where(vm =>
                    vm.IsAssignableToGenericType(typeof(IViewModel<>)) && !vm.IsAbstract && !vm.IsInterface
                ).Where(vm =>
                    !JaMapeadoNoProfile(mc, vm, vm.GetInterface(typeof(IViewModel<>).Name).GetGenericArguments()[0])
                    )
                .ToList()
                .ForEach(vm =>
                {
                    mc.CreateMap(vm, vm.GetInterface(typeof(IViewModel<>).Name).GetGenericArguments()[0]);
                });
        }
        /// <summary>
        /// Metodo para varificar se o mapeamento ja foi feito em algum profile
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        private static bool JaMapeadoNoProfile(IMapperConfigurationExpression mc, Type origem, Type destino)
        {
            return ((AutoMapper.Configuration.MapperConfigurationExpression)mc).Profiles.SelectMany(x => x.TypeMapConfigs)
                .Any(x =>
                    x.SourceType == origem && x.DestinationType == destino
                    );
        }
    }
}
