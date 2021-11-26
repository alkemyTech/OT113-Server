using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> : ICrud<T>
    {
    }
    public class Repository<T> : IRepository<T> where T : IEntityBase
    {
        IDbContext<T> _ctx;
        public Repository(IDbContext<T> ctx)
        {
            _ctx = ctx;
        }
        public void Delete(int id)
        {
            _ctx.Delete(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _ctx.GetAll();
        }
        public T GetById(int id)
        {
            return _ctx.GetById(id);
        }
        public T Save(T entity)
        {
            return _ctx.Save(entity);
        }

        public void Update(T entity)
        {
            _ctx.Update(entity);
        }
    }
}
