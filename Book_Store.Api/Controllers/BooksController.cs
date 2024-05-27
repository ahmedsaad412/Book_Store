using Book_Store.Core.Consts;
using Book_Store.Core.Entities;
using Book_Store.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var book = _unitOfWork.Books.Get(1);
            return Ok(book);
        }
        [HttpGet("GETALL")]
        public IActionResult GetAll()
        {
            var authors = _unitOfWork.Books.GetAll();
            return Ok(authors);
        }
        [HttpGet("FindWithTitle")]
        public IActionResult FindWithTitle()
        {
            var book = _unitOfWork.Books.Find(b => b.Title == "aaaa", new [] { "Author" });
            return Ok(book);
        } 
        [HttpGet("FindAll")]
        public IActionResult FindAll()
        {
            var books = _unitOfWork.Books.FindAll(b => b.Title.Contains("new book"), new [] { "Author" });
            return Ok(books);
        }
        [HttpGet("FindAllPagination")]
        public IActionResult FindAllbooks()
        {
            var books = _unitOfWork.Books.FindAll(b => b.Title.Contains("new book"), new [] { "Author" },1,2,c=>c.Id ,Order.Descending);
            return Ok(books);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook()
        {
            var book = new Book
            {
                Title = "test",
                AuthorId = 3
            };
            _unitOfWork.Books.Add(book);
            return Ok();
        }  
        [HttpPost("AddBooks")]
        public IActionResult AddBooks()
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Title = "hhh",
                    AuthorId = 3
                },
                new Book
                {
                    Title = "ssss",
                    AuthorId = 3
                },
                new Book
                {
                    Title = "sssss",
                    AuthorId = 3
                }
            };
           
            _unitOfWork.Books.AddRange(books);
            return Ok();
        }
    }
}
