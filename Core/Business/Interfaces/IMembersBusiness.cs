using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Entities;
using Core.Models.DTOs;

namespace Core.Business.Interfaces
{
    public interface IMembersBusiness
    {
        Task<IEnumerable<MemberDto>> GetAllMembers();

        void AddMember(MembersNameDto member);
        Member GetMemberById(int id);
        void UpdateMember(Member member, MemberDto update);
        void RemoveMember(int id);
    }
}
