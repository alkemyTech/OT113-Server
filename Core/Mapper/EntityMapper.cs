﻿using Abstractions;
using Core.Models;
using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public interface IEntityMapper
    {
        IEnumerable<MemberDto> mapMemberModelToDto(IEnumerable<Member> members);
        CategoryDto mapCategoryModeltoDto(Category category);
        IEnumerable<CategoryDtoGetAllResponse> mapCategoriesNamesModelToDto(IEnumerable<Category> categories);
        OrganizationDto MapOrganizationDtoToModel(Organization organization);
        TokenParameter MapUserLoginDtoToTokenParameter(UserLoginDto user);
        UserDto mapUserDTO(UserRegisterDto user);
        IEnumerable<SlidesDTO> Mapp(IEnumerable<Slides> slides);
        IEnumerable<ContactDto> MapContactsToContactDto(IEnumerable<Contacts> contacts);
        Activity ActivitieMapDto(ActivitiesDto activitie);
    }

    public class EntityMapper : IEntityMapper
    {
        public OrganizationDto MapOrganizationDtoToModel(Organization organization)
        {
            if (organization != null)
            {
                var organizationDto = new OrganizationDto
                {
                    Name = organization.Name,
                    Image = organization.Image,
                    Adress = organization.Adress,
                    Phone = organization.Phone,
                    Facebook = organization.Facebook,
                    Linkedin = organization.Linkedin,
                    Instagram = organization.Instagram
                };

                return organizationDto;
            }

            return null;
        }

        public TokenParameter MapUserLoginDtoToTokenParameter(UserLoginDto user)
        {
            return new TokenParameter
            {
                Email = user.Email,
                Password = user.Password
            };
        }



        public IEnumerable<MemberDto> mapMemberModelToDto(IEnumerable<Member> members)
        {

            List<MemberDto> membersDto = new List<MemberDto>();

            if (members != null)
            {
                foreach (var m in members)
                {

                    var memberDTO = new MemberDto
                    {
                        Name = m.Name,
                        FacebookUrl = m.FacebookUrl,
                        InstagramUrl = m.InstagramUrl,
                        LinkedinUrl = m.LinkedinUrl,
                        Image = m.Image,
                        Description = m.Description
                    };

                    membersDto.Add(memberDTO);
                }

                return membersDto;
            }

            return null;
        }



        public CategoryDto mapCategoryModeltoDto(Category category){

            if(category != null){
                CategoryDto categoryDto = new CategoryDto{
                    Name = category.Name,
                    Description = category.Description,
                    Image = category.Image
                };

                return categoryDto;
            } 

            return null;
        }
        

        public IEnumerable<CategoryDtoGetAllResponse> mapCategoriesNamesModelToDto(IEnumerable<Category> categories)
        {

            List<CategoryDtoGetAllResponse> categoriesDto = new List<CategoryDtoGetAllResponse>();

            if (categories != null)
            {
                foreach (var c in categories)
                {

                    var categoryDTO = new CategoryDtoGetAllResponse
                    {
                        Name = c.Name
                    };

                    categoriesDto.Add(categoryDTO);
                }

                return categoriesDto;
            }

            return null;

        }

        public UserDto mapUserDTO(UserRegisterDto user)
        {
            UserDto newUser = new UserDto
            {
                firstName = user.firstName,
                lastName = user.lastName,
                Email = user.Email
            };

            return newUser;
        }

        public IEnumerable<SlidesDTO> Mapp(IEnumerable<Slides> slides)
        {
            if (slides != null)
            {
                List<SlidesDTO> listSlides = new List<SlidesDTO>();

                foreach (var slide in slides)
                {
                    var slideDTO = new SlidesDTO
                    {
                        ImgUrl = slide.ImgUrl,
                        Order = slide.Order
                    };
                    listSlides.Add(slideDTO);
                }

                return listSlides;
            }

            return null;
        }

        public IEnumerable<ContactDto> MapContactsToContactDto(IEnumerable<Contacts> contacts)
        {
            List<ContactDto> mappedContacts = new List<ContactDto>();

            foreach (var contact in contacts)
            {
                var mappedContact = new ContactDto
                {
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Message = contact.Message
                };

                mappedContacts.Add(mappedContact);
            }

            return mappedContacts;
        }

        public Activity ActivitieMapDto(ActivitiesDto activitie) 
        {
            
            Activity newActivitie = new Activity
            {
                Name = activitie.Name,
                Content = activitie.Content,
                Image = activitie.Image
            };

            return newActivitie;
        }
    }
}
