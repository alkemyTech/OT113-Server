using Abstractions;
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
        List<UserDto> mapUsers(IEnumerable<User> users);
        IEnumerable<SlidesDTO> Mapp(IEnumerable<Slides> slides);
        IEnumerable<CommentsDto> MappComments(IEnumerable<Comment> comments);
        IEnumerable<ContactDto> MapContactsToContactDto(IEnumerable<Contacts> contacts);
        Contacts MapContactDtoToContact(ContactDto contact);
        NewsDto mapNews(News news);
        Category mapNewCategory(CategoryDto category);
        News NewsMapDto(NewNewsDto news);
        Member MemberMapDto(MembersNameDto member);
        Testimonials TestimonialsMapDto(TestimonailsDto testimonial);
        Activity ActivitieMapDto(ActivitiesDto activitie);
        Organization MapOrganizationDtoPostRequestToModel(Organization organization, OrganizationDtoPostRequest organizationDto);
        Comment MapCommentDtoForCreationToComment(CommentDtoForCreation comment);
        News UpdateNews(News news, NewNewsDto newsDto);



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
                    Address = organization.Address,
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



        public CategoryDto mapCategoryModeltoDto(Category category)
        {

            if (category != null)
            {
                CategoryDto categoryDto = new CategoryDto
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

        public List<UserDto> mapUsers(IEnumerable<User> users)
        {
            List<UserDto> usersDTO = new List<UserDto>();

            foreach (var user in users)
            {
                UserDto userAdd = new UserDto
                {
                    firstName = user.firstName,
                    lastName = user.lastName,
                    Email = user.Email,
                };
                usersDTO.Add(userAdd);
            }

            return usersDTO;
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


        public IEnumerable<CommentsDto> MappComments(IEnumerable<Comment> comments)
        {
            List<CommentsDto> listComments = new List<CommentsDto>();
            comments = comments.OrderBy(com => com.modifiedAt);
            foreach (var comm in comments)
            {
                CommentsDto comment = new CommentsDto
                {
                    Body = comm.Body
                };

                listComments.Add(comment);
            }

            return listComments;
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


        public Contacts MapContactDtoToContact(ContactDto contact)
        {
            return new Contacts
            {
                Name = contact.Name,
                Phone = contact.Phone,
                Email = contact.Email,
                Message = contact.Message,
                isDelete = false,
                modifiedAt = DateTime.Now.Date
            };
        }

        public NewsDto mapNews(News news)
        {
            NewsDto newsDTO = new NewsDto
            {
                Name = news.Name,
                Image = news.Image,
                Content = news.Content,
                CategoryID = news.CategoryId
            };

            return newsDTO;

        }

        public Category mapNewCategory(CategoryDto category)
        {
            Category newCat = new Category
            {
                Name = category.Name,
                Description = category.Description,
                Image = category.Image,
                isDelete = false,
                modifiedAt = DateTime.Now
            };

            return newCat;
        }


        public News NewsMapDto(NewNewsDto news)
        {
            News newNews = new News
            {
                Name = news.Name,
                Content = news.Content,
                Image = news.Image,
                CategoryId = news.CategoryId
            };
            return newNews;
        }

    
        public Member MemberMapDto(MembersNameDto member)
        {
            Member newMember = new Member
            {
                Name = member.Name,
                Image = member.Image
            };

            return newMember;
        }



        public Testimonials TestimonialsMapDto(TestimonailsDto testimonial)
        {
            Testimonials newTestimonial = new Testimonials
            {
                Name = testimonial.Name,
                Content = testimonial.Content
            };
            return newTestimonial;
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


        public Organization MapOrganizationDtoPostRequestToModel(Organization organization, OrganizationDtoPostRequest organizationDto)
        {

            organization.isDelete = false;
            organization.modifiedAt = DateTime.Now;
            organization.Name = organizationDto.Name;
            organization.Image = organizationDto.Image;
            organization.Address = organizationDto.Address;
            organization.Phone = organizationDto.Phone;
            organization.WelcomeText = organizationDto.WelcomeText;
            organization.AboutUsText = organizationDto.AboutUsText;
            organization.Facebook = organizationDto.Facebook;
            organization.Linkedin = organizationDto.Linkedin;
            organization.Instagram = organizationDto.Instagram;

            return organization;
        }

        public Comment MapCommentDtoForCreationToComment(CommentDtoForCreation comment)
        {
            return new Comment
            {
                userId = comment.userId,
                Body = comment.Body,
                newsId = comment.newsId,
                isDelete = false,
                modifiedAt = DateTime.Now.Date
            };
        }

        public News UpdateNews(News news, NewNewsDto newsDto)
        {
            news.Name = newsDto.Name;
            news.Image = newsDto.Image;
            news.Content = newsDto.Content;
            news.CategoryId = newsDto.CategoryId;

            return news;
        }
    }
}
