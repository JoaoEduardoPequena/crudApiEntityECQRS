using Microsoft.OpenApi.Models;

namespace WebAPI.Config
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(d =>
            {
                d.SwaggerDoc("geral", new OpenApiInfo
                {
                    Title = "Geral",
                    Version = "v1",
                    Description =
                        "Documentaçao Referente as Requisições dos usuário e autencaçao",
                });

            });
        }
    }
}
