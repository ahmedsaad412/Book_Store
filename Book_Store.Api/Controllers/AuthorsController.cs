using Book_Store.Core.Entities;
using Book_Store.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //private readonly IBaseReposatory<Author> _unitOfWork.Authors;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult Get()
        {
            var author = _unitOfWork.Authors.Get(2);
            return Ok(author);
        }
        [HttpGet("GETALL")]
        public IActionResult GetAll()
        {
            var authors = _unitOfWork.Authors.GetAll();
            return Ok(authors);
        }
        [HttpGet("FindByName")]
        public IActionResult FindByName()
        {
            var authorName = _unitOfWork.Authors.Find(b=>b.Name=="test3");
            return Ok(authorName);
        }
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor()
        {
            var author = new Author
            {
                Name = "test4"
                
            };
            _unitOfWork.Authors.Add(author);
            return Ok();
        }

        [HttpPost("AddAuthors")]
        public IActionResult AddAuthors()
        {
            List<Author> authors = new List<Author>
            {
                new Author
                {
                    Name = "test5"
                },
                new Author
                {
                    Name = "test6"
                }
            };
            _unitOfWork.Authors.AddRange(authors);
            return Ok();
        }
    }
}
