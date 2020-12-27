using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specafications
{
   public interface ISpecifcation<T> 
    {
        Expression<Func<T,bool>> Criteria { get; }

        Expression<Func<T, Object>> OrderBy { get; }
        Expression<Func<T, Object>> OrderByDesc { get; }

        List<Expression<Func<T, Object>>> Includes { get; }

        int Take { get; }
        int Skip { get; }
        bool PagingEnable { get; }


    }
}
