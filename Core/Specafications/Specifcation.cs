using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specafications
{
   public class Specifcation<T> : ISpecifcation<T>
    {

        public Specifcation() { }
        public Specifcation(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool PagingEnable { get; private set; }

        public void AddInclude(Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }

        public void AddOrderBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }

        public void ApplyPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;
            PagingEnable = true;
        }
    }
}
