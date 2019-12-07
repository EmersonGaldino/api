using Dapper;
using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.utils.Helpers;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace galdino.funcional.data.persistence.Initiator
{
    public class Initiator
	{
        private static bool _register = false;

        #region Methods
        public static void RegisterModels()
        {
            if (_register) return;

            var tipoPadrao = typeof(UserDomain);//Colocar modelo padrão para mapeamento
            var entitidades = tipoPadrao
                .Assembly
                .GetTypes()?
                .Where(type => type.Namespace != null &&
                (type.GetCustomAttribute<TableAttribute>() != null ||
                               type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Any(x => Attribute.IsDefined(x, typeof(ColumnAttribute)))
                                ) &&
                               !type.IsGenericType && type.IsClass).ToList();
            entitidades?.ForEach(type =>
            {
                dynamic typeMap =
                    Activator.CreateInstance(typeof(ColumnAttributeTypeMapper<>).MakeGenericType(type));
                SqlMapper.SetTypeMap(type, typeMap);
            });
            _register = true;

            typeof(Initiator).Assembly.GetTypes()?.Where(x =>
                x.IsAssignableToGenericType(typeof(SqlMapper.TypeHandler<>)) && !x.IsAbstract
            )?.ToList().ForEach(x =>
            {
                var handler = Activator.CreateInstance(x);
                SqlMapper.AddTypeHandler(x.BaseType.GenericTypeArguments[0], (SqlMapper.ITypeHandler)handler);
            });
        }
        #endregion

    }
}
