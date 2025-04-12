namespace SRS.Core.Domain.Common
{
    public class Employee : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}
