using Application.Repository;
using Domain;

namespace Infraestructure
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly OrganizationDbContext _context;

        public OrganizationRepository(OrganizationDbContext context)
        {
            _context = context;
        }

        public List<Organization> GetAll()
        {
            return _context.Organizations.ToList();
        }

        public Organization GetById(int id)
        {
            var organization = _context.Organizations.SingleOrDefault(b => b.OrganizationId == id);
            
            return organization!;
        }
    }
}
