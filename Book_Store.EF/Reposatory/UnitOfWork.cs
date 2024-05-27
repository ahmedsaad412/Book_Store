using Book_Store.Core.Entities;
using Book_Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.EF.Reposatory
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseReposatory<Author> Authors { get; private set; }
        public IBaseReposatory<Book> Books { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            Authors =new BaseReposatory<Author>(_context);
            Books =new BaseReposatory<Book>(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
