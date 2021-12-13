﻿using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
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
        private readonly IEntityMapper _mapper;

        public MembersBusiness(IRepository<Member> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddMember(MembersNameDto member) 
        {
            var memberMapped = _mapper.MemberMapDto(member);
            _repository.Save(memberMapped);

        }
        public Member GetMemberById(int id) {
            return _repository.GetById(id);
        }

        public void RemoveMember(int id) { }
        public void UpdateMember(Member member, MemberDto update) {
            _mapper.mapUpdateMember(member, update);
            _repository.Update(member);
        }


        public async Task<IEnumerable<MemberDto>> GetAllMembers()
        {

            var members = await _repository.GetAll();

            var membersDto = _mapper.mapMemberModelToDto(members);

            return membersDto;
        }


    }
}
