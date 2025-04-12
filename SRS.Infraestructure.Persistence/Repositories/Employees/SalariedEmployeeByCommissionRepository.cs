using Microsoft.Extensions.Logging;
using SRS.Core.Application.Interfaces.Repositories;
using SRS.Core.Domain.Entities;
using SRS.Infraestructure.Persistence.Context;
using SRS.Infraestructure.Persistence.Repositories.Base;

namespace SRS.Infraestructure.Persistence.Repositories.Employees
{
    public class SalariedEmployeeByCommissionRepository : GenericRepository<SalariedEmployeeByCommission> , ISalariedEmployeeByCommissionRepository
    {
        private readonly SRSContext _context;
        private readonly ILogger<GenericRepository<SalariedEmployeeByCommission>> _logger;

        public SalariedEmployeeByCommissionRepository(SRSContext context, ILogger<GenericRepository<SalariedEmployeeByCommission>> logger) : base(context , logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
