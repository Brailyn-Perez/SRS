using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SRS.Core.Domain.Common;
using SRS.Core.Domain.Entities;
using System.Linq.Expressions;

namespace SRS.Infraestructure.Persistence.Context
{
    public class SRSContext : DbContext
    {
        public SRSContext(DbContextOptions<SRSContext> options) : base(options)
        {

        }
        #region "SoftDelete"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditableEntity).IsAssignableFrom(item.ClrType))
                {
                    var parameter = Expression.Parameter(item.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(AuditableEntity.IsDeleted));
                    var notDeleted = Expression.Not(property);
                    var lambda = Expression.Lambda(notDeleted, parameter);
                }
            }
        }
        #endregion
        #region AuditableConfiguration
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.UtcNow;
                        item.Entity.UserCreate = "exampleUser";
                        break;
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.UtcNow;
                        item.Entity.UserUpdate = "exampleUser";
                        break;

                    case EntityState.Deleted:
                        item.Entity.DeletedAt = DateTime.UtcNow;
                        item.Entity.UserDelete = "exampleUser";
                        break;
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion
        #region DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeOnCommission> EmployeesOnCommission { get; set; }
        public DbSet<HourlyEmployee> HourlyEmployees { get; set; }
        public DbSet<SalariedEmployee> SalariedEmployees { get; set; }
        public DbSet<SalariedEmployeeByCommission> salariedEmployeeByCommissions { get; set; }
        #endregion
    }
}
