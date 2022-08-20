using EJK.Licitacao.Data.Repository;
using EJK.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EJK.Licitacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        public MensagemController(IMensagemRepository repository)
        {
            this.Repository = repository;
        }

        public IMensagemRepository Repository { get; }
        [HttpPost("AddMensagemBulk")]
        public void AddMensagem(MensagemAddRequest request)
        {

        }
    }
}
