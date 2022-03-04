using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public MembershipTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MembershipType> GetAll()
        {
            return _context.MembershipTypes;
        }

        public MembershipType GetById(int id)
        {
            return _context.MembershipTypes.Find(id);
        }
        public void Add(MembershipType membershipType)
        {
            _context.MembershipTypes.Add(membershipType);
        }
        public void Delete(int id)
        {
            _context.MembershipTypes.Remove(GetById(id));
        }
        public void Update(MembershipType membershipType)
        {
            _context.MembershipTypes.Update(membershipType);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}