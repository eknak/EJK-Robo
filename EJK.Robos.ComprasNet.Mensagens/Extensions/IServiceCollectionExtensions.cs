using EJK.Robos.ComprasNet.Mensagens.Core;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace EJK.Robos.ComprasNet.Mensagens.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var clientCertificate = new X509Certificate2(
                Path.Combine("w:\\ejk", "44267947000139.pfx"), "Gremio@1903");

            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            handler.ClientCertificates.Add(clientCertificate);

            services.AddHttpClient("comprasnet", c =>
            {
            }).ConfigurePrimaryHttpMessageHandler(() => handler);

            services.AddCore(configuration);

            return services;
        }
    }
}
