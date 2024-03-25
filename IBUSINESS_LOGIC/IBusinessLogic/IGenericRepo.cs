using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> GetByIdAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<M_Return_Message> AddAsync(T entity);
        Task<M_Return_Message> UpdateAsync(T entity);
        Task<M_Return_Message> DeleteAsync(T entity);
    }
    
}
