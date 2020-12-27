using Core.Entities;
using Core.Interfaces;
using Core.Specafications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext context;

        public GenericRepository(StoreContext context) => this.context = context;

        public async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T> GetEntityWithSpec(ISpecifcation<T> specifcation) => await ApplySpecifcation(specifcation).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifcation<T> specifcation) => await ApplySpecifcation(specifcation).ToListAsync();

        public async Task<int> CountAsync(ISpecifcation<T> specifcation) => await ApplySpecifcation(specifcation).CountAsync();

        private IQueryable<T> ApplySpecifcation(ISpecifcation<T> specifcation) => SpacificationEvaluator<T>.GetQueryable(context.Set<T>().AsQueryable(), specifcation);

      
    }
}
