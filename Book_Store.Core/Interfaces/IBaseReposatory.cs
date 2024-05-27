using Book_Store.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Core.Interfaces
{
    public interface IBaseReposatory<T> where T:class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T,bool>> expression,string[] includes=null);
        IEnumerable<T> FindAll(Expression<Func<T,bool>> expression,string[] includes=null);
        IEnumerable<T> FindAll(
            Expression<Func<T,bool>> expression,string[]? includes=null 
            ,int? skip=null,int? take=null ,
            Expression<Func<T,object>>?orderBy=null,
            string order=Order.Ascending);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
    }
}
