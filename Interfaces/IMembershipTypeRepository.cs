using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibApp.Interfaces
{
    public interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetAll();
        MembershipType GetById(int id);
        public void Add(MembershipType membershipType);
        public void Update(MembershipType membershipType);
        public void Delete(int id);
        public void Save();
    }
}