
using BookManagement.Shared.Models.Dtos;
using System.Linq.Expressions;

namespace BookManagement.Server.DL.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);
        void SaveChanges();
        Task<IEnumerable<T>> GetItems(PaginationParameters parameters);
    }
}
