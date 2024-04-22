using AutoMapper;
using server.Business.Services.Interfaces;
using server.DataAccess.Repositories;

namespace server.Business.Services;

public class GenericServiceAsync<TEntity, TDto>(Repository<TEntity> genericRepository, IMapper mapper)
    : ReadServiceAsync<TEntity, TDto>(genericRepository, mapper), IGenericServiceAsync<TEntity, TDto>
    where TEntity : class
    where TDto : class
{
    private readonly Repository<TEntity> _genericRepository = genericRepository;
    private readonly IMapper _mapper = mapper;

    public async Task AddAsync(TDto dto)
    {
        await _genericRepository.AddAsync(_mapper.Map<TEntity>(dto));
    }

    public async Task DeleteAsync(int id)
    {
        await _genericRepository.DeleteByIdAsync(id);
    }

    public async Task UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _genericRepository.UpdateAsync(entity);
    }
}
