using Core.Business.Interfaces;
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
    public class ContactsBusiness : IContactsBusiness
    {
        private readonly IRepository<Contacts> _repository;
        private readonly IEntityMapper _mapper;

        public ContactsBusiness(IRepository<Contacts> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddContact(Contacts contact)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContactDto>> GetAllContacts()
        {
            var contacts = await _repository.GetAll();

            return _mapper.MapContactsToContactDto(contacts);
        }

        public Contacts GetContactById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contacts contact)
        {
            throw new NotImplementedException();
        }
    }
}
