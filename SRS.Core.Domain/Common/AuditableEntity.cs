namespace SRS.Core.Domain.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string UserCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserDelete { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
