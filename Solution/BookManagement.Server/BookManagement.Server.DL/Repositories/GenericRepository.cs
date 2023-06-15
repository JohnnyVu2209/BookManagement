

using BookManagement.Shared.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookManagement.Server.DL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected BookShopDbContext context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(BookShopDbContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            return context
                .Add(entity)
                .Entity;
        }

        public IEnumerable<T> All()
        {
            return context.Set<T>()
               .ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return context.Find<T>(id);
        }

        public IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            return _dbSet.Include(navigationPropertyPath);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            return context.Update(entity)
                .Entity;
        }

        public async Task<IEnumerable<T>> GetItems(PaginationParameters parameters)
        {
            IQueryable<T> query = context.Set<T>();

            if (!string.IsNullOrEmpty(parameters.SortBy))
            {
                string sortBy = parameters.SortBy;
                if (parameters.SortAscending)
                {
                    query = query.OrderBy(x => EF.Property<object>(x, sortBy));
                }
                else
                {
                    query = query.OrderByDescending(x => EF.Property<object>(x, sortBy));
                }
            }

            int skip = (parameters.PageNumber - 1) * parameters.PageSize;
            query = query.Skip(skip).Take(parameters.PageSize);

            return await query.ToListAsync();

        }
    }
}
