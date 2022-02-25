using LibApp.Data;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Repositories.Interfaces;

namespace LibApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        protected ApplicationDbContext context;
        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Genre> GetAll() => context.Genre.ToList();
    }
}