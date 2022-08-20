using EJK.Licitacao.Data.Repository;
using EJK.Shared.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJK.Licitacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TRepository, TEntity> : ControllerBase where TRepository : IBaseRepository<TEntity> where TEntity : IEntity
    {
        protected TRepository Repository { get; }

        public BaseController(TRepository repository)
        {
            this.Repository = repository;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public IList<TEntity> Get()
        {
            return Repository.GetAll().ToList();
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public async Task<TEntity?> Get(int id)
        {
            return await Repository.Find(id);
        }

        // POST api/<BaseController>
        [HttpPost]
        public async Task<TEntity> Post([FromBody] TEntity value)
        {
            return await Repository.Update(value);
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public async Task<TEntity> Put(int id, [FromBody] TEntity value)
        {
            return await Repository.Update(value);
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await Repository.Remove(id);
        }
    }
}
