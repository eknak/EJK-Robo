using EJK.Robos.ComprasNet.Mensagens.Core.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Robos.ComprasNet.Mensagens.Core.Services
{
    public interface IMensagemScraperService
    {
        Task<List<MensagemModelComprasNet>> GetMensagens(GetMensagensModel filtro);
    }

    internal class MensagemScraperService : IMensagemScraperService
    {
        public async Task<List<MensagemModelComprasNet>> GetMensagens(GetMensagensModel filtro)
        {
            //string url = "http://comprasnet.gov.br/livre/Pregao/Mensagens_Acomp.asp?prgcod=1050264";
            string url = "https://www.comprasnet.gov.br/pregao/fornec/Mensagens_Sessao_Publica.asp?prgCod=1054381";

            //string url = "http://comprasnet.gov.br/livre/Pregao/Mensagens_Sessao_Publica.asp?prgCod=1050264";

            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);


            var buffer = await response.Content.ReadAsByteArrayAsync();
            var byteArray = buffer.ToArray();
            var html = Encoding.Latin1.GetString(byteArray, 0, byteArray.Length);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var trs = doc.DocumentNode.SelectNodes("//tr");
            var result = new List<MensagemModelComprasNet>();
            foreach (var tr in trs)
            {
                var tds = tr.SelectNodes("td");

                var nobr = tds[0].SelectNodes("nobr").FirstOrDefault();
                var dadosMsg = tds[0].InnerText.Replace("\r\n", "").Split(":", 2);

                var tipoMensagem = dadosMsg[0];
                DateTime dataMensagem = DateTime.ParseExact(dadosMsg[1].Replace("(", "").Replace(")", ""), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                var mensagemTxt = tds[1].InnerText.Replace("\r\n", "");

                var mensagem = new MensagemModelComprasNet() { Data = dataMensagem, Texto = mensagemTxt, Tipo = tipoMensagem };

                result.Add(mensagem);
            }

            return result;
        }
    }
}
