using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Robos.ComprasNet.Mensagens.Core.Services
{
    public interface ILoginService
    {
        Task<String> Test();
    }
    internal class LoginService : ILoginService
    {
        HttpClient client;
        public LoginService(IHttpClientFactory httpFactory)
        {
            this.client = httpFactory.CreateClient("comprasnet");
        }
        public async Task<String> Test()
        {
            Dictionary<string, string> urls = new Dictionary<string, string>();

            urls.Add("https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br", "GET");
            urls.Add("https://comprasnet.gov.br/seguro/loginPortal.asp", "GET");
            urls.Add("https://comprasnet.gov.br/seguro/loginPortalFornecedor.asp", "POST");
            

            urls.Add("https://sso.acesso.gov.br/authorize?response_type=code&client_id=comprasnet.gov.br&scope=openid+profile+email+phone+govbr_confiabilidades&redirect_uri=https://comprasnet.gov.br/seguro/landing_sso.asp", "GET");
            
            urls.Add("https://comprasnet.gov.br/intro.htm", "GET");
            urls.Add("https://comprasnet.gov.br/main2.asp", "GET");
            
            urls.Add("https://comprasnet.gov.br/main.asp", "GET");
            urls.Add("https://comprasnet.gov.br/main.asp?login=ejkmat9x", "GET");
            urls.Add("https://comprasnet.gov.br/assinadas/pregao.asp", "GET");
            //urls.Add("https://comprasnet.gov.br/pregao/fornec/assinadas/pregao.asp", "GET");
            //urls.Add("xxxx", "GET");
            //urls.Add("xxxx", "GET");


            string result = "";

            foreach (var url in urls)
            {
                HttpResponseMessage res = null;
                if (url.Value == "GET")
                {
                    res = await client.GetAsync(url.Key);
                }
                else if (url.Value == "POST")
                {
                    res = await client.PostAsync(url.Key, null);
                }

                //https://certificado.sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id=18231bcfb5b
                //https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id=18231b7557f
                //res.EnsureSuccessStatusCode();

                result = await res.Content.ReadAsStringAsync();
                var originator = res.RequestMessage.RequestUri.ToString();
                if (originator.StartsWith("https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id"))
                {
                    
                    var url2 = $"https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id={res.RequestMessage.RequestUri.ToString().Replace("https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id=", "")}";
                    var res2 = await client.GetAsync(url2);
                    result = await res2.Content.ReadAsStringAsync();

                    var url3 = $"https://certificado.sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id={res.RequestMessage.RequestUri.ToString().Replace("https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br&authorization_id=", "")}";
                    var res3 = await client.GetAsync(url3);
                    result = await res2.Content.ReadAsStringAsync();
                }


            }

            return result;

        }
        //public async Task<String> Test()
        //{
        //    string url1 = "https://sso.acesso.gov.br/login?client_id=comprasnet.gov.br";

        //    var res1 = await client.GetAsync(url1);

        //    res1.EnsureSuccessStatusCode();

        //    await res1.Content.ReadAsStringAsync();

        //    var url2 = "https://www.comprasnet.gov.br/intro.htm";

        //    var res2 = await client.GetAsync(url2);

        //    res2.EnsureSuccessStatusCode();

        //    await res2.Content.ReadAsStringAsync();

        //    var url3 = "https://www.comprasnet.gov.br/main2.asp";

        //    var res3 = await client.GetAsync(url3);

        //    res3.EnsureSuccessStatusCode();

        //    return await res3.Content.ReadAsStringAsync();

        //}
    }
}
