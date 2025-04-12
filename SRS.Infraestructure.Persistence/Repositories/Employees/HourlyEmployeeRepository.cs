using Microsoft.Extensions.Logging;
using SRS.Core.Application.Interfaces.Repositories;
using SRS.Core.Domain.Entities;
using SRS.Infraestructure.Persistence.Context;
using SRS.Infraestructure.Persistence.Repositories.Base;

namespace SRS.Infraestructure.Persistence.Repositories.Employees
{
    public class HourlyEmployeeRepository : GenericRepository<HourlyEmployee> , IHourlyEmployeeRepository
    {
        private readonly SRSContext _context;
        private readonly ILogger<GenericRepository<HourlyEmployee>> _logger;

        public HourlyEmployeeRepository(SRSContext context, ILogger<GenericRepository<HourlyEmployee>> logger) : base(context , logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
