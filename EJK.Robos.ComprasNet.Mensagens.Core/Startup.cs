using EJK.Robos.ComprasNet.Mensagens.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EJK.Robos.ComprasNet.Mensagens.Core
{
    public static class Startup
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IMensagemScraperService, MensagemScraperService>();
            services.AddSingleton<ILoginService, LoginService>();

            return services;
        }

    }
}