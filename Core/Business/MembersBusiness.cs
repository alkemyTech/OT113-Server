using Core.Business.Interfaces;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class MembersBusiness : IMembersBusiness
    {
        private readonly IRepository<Member> _repository;

        public MembersBusiness(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public void AddMember() { }
        public void RemoveMember(int id) { }
        public void UpdateMember(Member member) { }
        public Member GetMemberById() { throw new NotImplementedException(); }
        public async Task<IEnumerable<Member>> GetAllMembers() { throw new NotImplementedException(); }
    }
}
