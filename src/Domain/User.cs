namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

    }
}
