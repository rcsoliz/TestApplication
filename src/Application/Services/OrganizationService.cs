using Application.Repository;
using Application.Services.Interfaces;
using Domain;

namespace Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public List<Organization> GetAll()
        {
            var organizations = _organizationRepository.GetAll();
            return organizations;
        }

        public Organization GetById(int id)
        {
            var organization = _organizationRepository.GetById(id);
            return organization;    
        }
    }
}
