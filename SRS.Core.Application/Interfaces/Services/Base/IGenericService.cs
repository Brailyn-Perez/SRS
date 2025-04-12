namespace SRS.Core.Application.Interfaces.Services.Base
{
    public interface IGenericService<vm , Save , Update> 
        where vm : class
        where Save : class
        where Update : class
    {
        public Task<IEnumerable<vm>> GetVmsAsync();
    }
}
