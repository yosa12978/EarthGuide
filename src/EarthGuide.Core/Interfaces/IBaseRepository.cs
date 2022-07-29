using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarthGuide.Core.Domain;

namespace EarthGuide.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        Task Delete(string id);
        Task Update(T entity);
    }
}
