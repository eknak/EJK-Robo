using EJK.Robos.ComprasNet.Mensagens.Core.Models;
using EJK.Robos.ComprasNet.Mensagens.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EJK.Robos.ComprasNet.Mensagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMensagens : ControllerBase
    {
        private readonly IMensagemScraperService mensagemScraper;

        public TestMensagens(IMensagemScraperService mensagemScraper)
        {
            this.mensagemScraper = mensagemScraper;
        }

        [HttpPost]
        public async Task<List<MensagemModelComprasNet>> GetMensagens(GetMensagensModel model)
        {
            return await this.mensagemScraper.GetMensagens(model);
        }
        [HttpGet]
        public async Task<string> TestLogin([FromServices] ILoginService service)
        {
            return await service.Test();
        }
    }
}
