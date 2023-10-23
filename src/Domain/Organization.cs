namespace Domain
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public int SlugTenant { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
