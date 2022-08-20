using EJK.Licitacao.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EJK.Licitacao.Data
{
    public static class Startup
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PregaoContext>(x => x.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddTransient<IMensagemRepository, MensagemRepository>();

            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddTransient<IPregaoRepository, PregaoRepository>();

            return services;
        }

    }
}