using EJK.Licitacao.Data.Repository;
using EJK.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJK.Licitacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController<IClienteRepository, Cliente>
    {
        public ClienteController(IClienteRepository repository) : base(repository)
        {
        }
    }
}
