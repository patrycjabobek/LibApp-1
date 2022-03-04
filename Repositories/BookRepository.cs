using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Interfaces;

namespace LibApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected ApplicationDbContext context;
        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return context.Books.Include(b => b.Genre);
        }
        public Book GetById(int id) => context.Books.Include(b => b.Genre).SingleOrDefault(c => c.Id == id);
        public void Add(Book book) => context.Books.Add(book);
        public void Update(Book book) => context.Books.Update(book);
        public void Delete(int id) => context.Books.Remove(GetById(id));
        public void Save() => context.SaveChanges();
    }
}