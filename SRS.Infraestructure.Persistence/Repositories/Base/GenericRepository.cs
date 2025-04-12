using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SRS.Core.Domain.Repositories;
using SRS.Infraestructure.Persistence.Context;

namespace SRS.Infraestructure.Persistence.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SRSContext _context;
        private readonly ILogger<GenericRepository<T>> _logger;
        public GenericRepository(SRSContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {

                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
            }

        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"Id Negative {id}");
            }

            if (id > int.MaxValue)
            {
                throw new Exception("id is invalid");
            }

            try
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
            }


        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($"Id Negative {id}");
            }

            if (id > int.MaxValue)
            {
                throw new Exception("id is invalid");
            }

            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
            }

            return null;
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {

                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR: {ex.Message}");
            }

        }
    }
}
