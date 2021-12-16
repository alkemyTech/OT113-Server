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
    public class OrganizationBusiness : IOrganizationBusiness
    {
        private readonly IRepository<Organization> _repository;
        private readonly IEntityMapper _mapper;
        private readonly IRepository<Slides> _repositorySlides;

        public OrganizationBusiness(IRepository<Organization> repository, IEntityMapper mapper, IRepository<Slides> repositorySlides)
        {
            _repository = repository;
            _mapper = mapper;
            _repositorySlides = repositorySlides;
        }

        public OrganizationDto GetById(int id)
        {
            var organization = _repository.GetById(id);

            var slides = _repositorySlides.GetAll();

            var slidesOrg = new List<Slides>();

            foreach (var slide in slides.Result.ToList())
            {
                if (slide.OrganizationId == organization.Id)
                {
                    slidesOrg.Add(slide);
                }
            }

            var slidesOrgdto = _mapper.Mapp(slidesOrg);

            slidesOrgdto.OrderBy(s => s.Order);

            return _mapper.MapOrganizationDtoToModel(organization, slidesOrgdto.ToList());
        }

        public Organization GetOrg(int id)
        {
            var organization = _repository.GetById(id);

            return organization;
        }


        public void UpdateOrganization(OrganizationDtoPostRequest organizationDto)
        {

            var organizationEdit = _repository.GetById(organizationDto.Id);
            _mapper.MapOrganizationDtoPostRequestToModel(organizationEdit, organizationDto);
            _repository.Update(organizationEdit);
        }

        public void DeleteOrganization(int id) { }

        public void InsertOrganization() { }
    }
}
