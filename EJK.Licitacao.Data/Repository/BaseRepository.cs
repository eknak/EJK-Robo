using EJK.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Licitacao.Data.Repository
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<T> Add(T entity);
        Task<T?> Find(int id);
        Task<int> Remove(int id);
        Task<T> Update(T entity);
        IQueryable<T> GetAll();
    }

    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {

        public BaseRepository(PregaoContext context)
        {
            this.Context = context;
        }

        protected PregaoContext Context { get; }

        public async Task<T> Add(T entity)
        {
            this.Context.Add(entity);
            await this.Context.SaveChangesAsync();
            return entity;

        }
        public async Task<T> Update(T entity)
        {
            this.Context.Attach(entity);
            await this.Context.SaveChangesAsync();
            return entity;

        }
        public async Task<int> Remove(int id)
        {
            var entity = await this.Find(id);
            
            if (entity == null)
                return 0;

            this.Context.Remove(entity);
            return await this.Context.SaveChangesAsync();

        }
        public async Task<T?> Find(int id)
        {
            return await this.Context.Set<T>().FindAsync(id);

        }

        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>();
        }
    }
}
