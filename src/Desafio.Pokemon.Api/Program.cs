
using Desafio.Pokemon.Api.Configurations;

namespace Desafio.Pokemon.Api
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAppConnections(builder.Configuration);

            builder.Services.AddAndConfigureControllers();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.ResolveDependencies();            

            var app = builder.Build();

            app.UseDocumentation();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }    
}
