namespace server.Business.Services.Interfaces;

public interface IReadServiceAsync<TEntity, TDto>
    where TEntity : class
    where TDto : class
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(int id);
}
