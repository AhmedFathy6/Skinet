using Core.Entities;
using Core.Specafications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpacificationEvaluator <TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQuery , ISpecifcation<TEntity> specifcation)
        {
            if ( specifcation.Criteria != null)
            {
                inputQuery = inputQuery.Where(specifcation.Criteria);
            }

            if (specifcation.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(specifcation.OrderBy);
            }

            if (specifcation.OrderByDesc != null)
            {
                inputQuery = inputQuery.OrderByDescending(specifcation.OrderByDesc);
            }

            if (specifcation.PagingEnable)
            {
                inputQuery = inputQuery.Skip(specifcation.Skip).Take(specifcation.Take);
            }

            inputQuery = specifcation.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
