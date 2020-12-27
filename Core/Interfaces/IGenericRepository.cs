using Core.Entities;
using Core.Specafications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecifcation<T> specifcation);
        Task<IReadOnlyList<T>> ListAsync(ISpecifcation<T> specifcation);
        Task<int> CountAsync(ISpecifcation<T> specifcation);
    }
}
