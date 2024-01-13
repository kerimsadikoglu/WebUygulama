using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UygulamaDBContext _uygulamaDBContext;
        internal DbSet<T> dbSet;

        public Repository(UygulamaDBContext uygulamaDBContext)
        {
            _uygulamaDBContext = uygulamaDBContext;
            this.dbSet = _uygulamaDBContext.Set<T>();
        }
        public void Ekle(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filtre)
        {
            IQueryable<T> sorgu = dbSet;
            sorgu = sorgu.Where(filtre);
            return sorgu.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> sorgu = dbSet;
            return sorgu.ToList();
        }

        public void Sil(T entity)
        {
            dbSet.Remove(entity);
        }

        public void SilAralik(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
