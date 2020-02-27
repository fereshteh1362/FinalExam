using System.Collections.Generic;
using System.Threading.Tasks;


namespace ExamFereshteh.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task Add(T entity);
        Task Delete(object id);
        Task Update(T entity);
        Task Save();
    }
}