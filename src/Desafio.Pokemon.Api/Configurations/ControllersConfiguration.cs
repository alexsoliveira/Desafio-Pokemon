using Desafio.Pokemon.Api.Filters;

namespace Desafio.Pokemon.Api.Configurations
{
    public static class ControllersConfiguration
    {
        public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(options
                => options.Filters.Add(typeof(ApiGlobalExceptionFilter))
            );

            services.AddCors(options =>
            {

                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .WithMethods("")
                            .WithOrigins("")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader());
            });

            services.AddDocumentation();

            return services;
        }

        private static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static WebApplication UseDocumentation(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}