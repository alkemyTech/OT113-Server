﻿using Abstractions;
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
        OrganizationDto Map(Organization organization);
        IEnumerable<MemberDto> mapMemberModelToDto(IEnumerable<Member> members);
        CategoryDtoGetDetailResponse mapCategoryModeltoDto(Category category);
        IEnumerable<CategoryDtoGetAllResponse> mapCategoriesNamesModelToDto(IEnumerable<Category> categories);
    }

    public class EntityMapper : IEntityMapper
    {
        public OrganizationDto Map(Organization organization)
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



        public CategoryDtoGetDetailResponse mapCategoryModeltoDto(Category category)
        {

            if (category != null)
            {
                CategoryDtoGetDetailResponse categoryDto = new CategoryDtoGetDetailResponse
                {
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


    }
}
