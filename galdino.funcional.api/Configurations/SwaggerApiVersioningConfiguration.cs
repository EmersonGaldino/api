using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace galdino.funcional.api.Configurations
{
    public class SwaggerApiVersioningConfiguration
	{
        public static void Register(IServiceCollection app)
        {
            app.AddSwaggerGen(
                options =>
                {
                    AdicionarVersoes(options);

                    options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
                    options.CustomSchemaIds(o => o.FullName);

                    options.IncludeXmlComments(XmlCommentsFilePath, true);
                    options.DescribeAllEnumsAsStrings();
                    options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        Description = "Emerson Galdino API. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });

                    var security = new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", new string[] { }},
                    };

                    options.AddSecurityRequirement(security);
                });
        }

        private static void AdicionarVersoes(SwaggerGenOptions options)
        {
            options.SwaggerDoc($"v1.0", new Info()
            {
                Title = $"Galdino API's v1.0",
                Version = "1.0",
                Description = "Esta API foi desenvolvida com o intuito de executar o teste proposto. \n Para executar este projeto basta apenas rodar o projeto, pois o banco de dados está online (Após irei excluir o banco de dados). \n Criei o projeto com a arquitetura que entendo ser boa para desenvolver e dar manutenção posterior.\n <h3>Espero que curtam.</h3>",
                Contact = new Contact() { Name = "Emerson Galdino", Email = "emersongaldino@hotmail.com",Url = "https://linkedin.com/in/emerson-galdino-88936338" }
            });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                return xmlPath;
            }
        }
    }
}
