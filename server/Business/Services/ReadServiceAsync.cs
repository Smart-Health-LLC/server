using AutoMapper;
using server.Business.Services.Interfaces;
using server.DataAccess.Interfaces;

namespace server.Business.Services;

public class ReadServiceAsync<TEntity, TDto>(IRepository<TEntity> genericRepository, IMapperBase mapper)
    : IReadServiceAsync<TEntity, TDto>
    where TEntity : class
    where TDto : class
{
    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        try
        {
            var result = await genericRepository.GetAllAsync();

            if (result.Any())
                return mapper.Map<IEnumerable<TDto>>(result);
            throw new EntityNotFoundException($"No {typeof(TDto).Name}s were found");
        }
        catch (EntityNotFoundException ex)
        {
            var message = $"Error retrieving all {typeof(TDto).Name}s";

            throw new EntityNotFoundException(message, ex);
        }
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
        // try
        // {
        //     var result = await genericRepository.GetByIdAsync(id);
        //
        //     if (result is null) throw new EntityNotFoundException($"Entity with ID {id} not found.");
        //
        //     return mapper.Map<TDto>(result);
        // }
        //
        // catch (EntityNotFoundException ex)
        // {
        //     var message = $"Error retrieving {typeof(TDto).Name} with Id: {id}";
        //
        //     throw new EntityNotFoundException(message, ex);
        // }
    }
}
