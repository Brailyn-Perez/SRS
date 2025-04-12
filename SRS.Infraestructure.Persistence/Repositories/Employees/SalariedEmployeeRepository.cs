using Microsoft.Extensions.Logging;
using SRS.Core.Application.Interfaces.Repositories;
using SRS.Core.Domain.Entities;
using SRS.Infraestructure.Persistence.Context;
using SRS.Infraestructure.Persistence.Repositories.Base;

namespace SRS.Infraestructure.Persistence.Repositories.Employees
{
    public class SalariedEmployeeRepository : GenericRepository<SalariedEmployee>, ISalariedEmployeeRepository
    {
        private readonly SRSContext _context;
        private readonly ILogger<GenericRepository<SalariedEmployee>> _logger;

        public SalariedEmployeeRepository(SRSContext context, ILogger<GenericRepository<SalariedEmployee>> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
