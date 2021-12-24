using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Entities;
using Core.Models.DTOs;
using Abstractions;

namespace Core.Business.Interfaces
{
    public interface IMembersBusiness
    {
        Task<IEnumerable<MemberDto>> GetAllMembers();
        void AddMember(MembersDtoResponse member);
        Member GetMemberById(int id);
        void UpdateMember(Member member, MemberDto update);
        void RemoveMember(int id);
        Task<IEnumerable<MembersNameDto>> GetAllMembersP(IPaginationFilter filter);
        int CountMembers();
<<<<<<< HEAD
        
=======
        MemberDto GetMember(int id);
>>>>>>> 577ecb38bda0f989ba6543a38cefab1a4828cce5
    }
}
