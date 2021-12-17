using Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntityBase
    {
        DbSet<T> _items;
        ApiDbContext _ctx;
        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();
        }

        public int Count()
        {
            return _items.Count();
        }

        public void Delete(int id)
        {
            var item = _items.Find(id);
            item.isDelete = true;
            item.modifiedAt = DateTime.Now;
            _ctx.SaveChanges();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _items.ToListAsync();
        }
        public T GetById(int id)
        {
            return _items.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> PaginatedGetAll(IPaginationFilter filter)
        {
            return await _items.Skip((filter.PageNumber - 1) * filter.PageSize)
                               .Take(filter.PageSize)
                               .ToListAsync();
        }

        public T Save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _items.Update(entity);
            _ctx.SaveChanges();
        }
    }
}
