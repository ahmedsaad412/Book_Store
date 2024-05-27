using Book_Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Core.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IBaseReposatory<Author> Authors{ get; }
        IBaseReposatory<Book> Books{ get; }

        int Complete();
    }
}
