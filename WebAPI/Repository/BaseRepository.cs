using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Context;

namespace WebAPI.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly Context.AppContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository()
        {
            _context = new Context.AppContext();
            DbSet = _context.Set<TEntity>();
        }
        public TEntity Add(TEntity obj)
        {

            obj = DbSet.Add(obj);
            _context.SaveChanges();
            return obj;

        }
        public TEntity Update(TEntity obj)
        {

            var entry = _context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            _context.SaveChanges();


            return obj;
        }
        public TEntity Delete(TEntity obj)
        {

            var entry = _context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();

            return obj;

        }
       
        public TEntity FirstOrDefault() => _context.Set<TEntity>().FirstOrDefault();
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().FirstOrDefault(predicate);
        public List<TEntity> ToList() => _context.Set<TEntity>().ToList();
        public List<TEntity> ToList(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate).ToList();
    }
}
