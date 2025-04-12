using Microsoft.Extensions.Logging;
using SRS.Core.Application.Interfaces.Repositories;
using SRS.Core.Domain.Entities;
using SRS.Infraestructure.Persistence.Context;
using SRS.Infraestructure.Persistence.Repositories.Base;

namespace SRS.Infraestructure.Persistence.Repositories.Employees
{
    public class EmployeeOnCommissionRepository : GenericRepository<EmployeeOnCommission>, IEmployeeOnCommissionRepository
    {
        private readonly ILogger<GenericRepository<EmployeeOnCommission>> _logger;
        private readonly SRSContext _context;
        public EmployeeOnCommissionRepository(SRSContext context, ILogger<GenericRepository<EmployeeOnCommission>> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
