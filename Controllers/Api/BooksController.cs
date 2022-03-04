using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using LibApp.Interfaces;
using System.Net;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;

        }

        // GET /api/books
        [HttpGet]
        [Authorize]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetAll()
                .Select(_mapper.Map<Book, BookDto>);
            return Ok(books);
        }

        //Get /api/book/{id}
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetById(id);

                if (book == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        [Authorize(Roles = "StoreManager, Owner")]
        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public void Update(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bookInDb = _bookRepository.GetById(id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _mapper.Map(bookDto, bookInDb);
            _bookRepository.Save();
        }

        // DELETE /api/books
        [HttpDelete("{id}")]
        [Route("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult DeleteBook(int id)
        {
            if (_bookRepository.GetById(id) == null)
            {
                return NotFound();
            }
            _bookRepository.Delete(id);
            _bookRepository.Save();
            return Ok();
        }

        private IMapper _mapper;
    }
}