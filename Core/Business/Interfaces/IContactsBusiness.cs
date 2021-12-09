using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface IContactsBusiness
    {
        void AddContact(ContactDto contact);
        void RemoveContact(int id);
        void UpdateContact(Contacts contact);
        Contacts GetContactById(int id);
        Task<IEnumerable<ContactDto>> GetAllContacts();
    }
}
