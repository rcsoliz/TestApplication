using Domain;

namespace Application.Repository
{
    public interface IOrganizationRepository
    {
        List<Organization> GetAll();
        Organization GetById(int id);
    }
}
