using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.Include(a => a.MembershipType);
        }

        public Customer GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }
        public void Delete(int id)
        {
            _context.Customers.Remove(GetById(id));
        }
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}