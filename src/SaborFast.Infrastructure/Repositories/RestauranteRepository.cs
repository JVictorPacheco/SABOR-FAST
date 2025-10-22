using Microsoft.EntityFrameworkCore;
using SaborFast.Core.Entities;
using SaborFast.Core.Interfaces;
using SaborFast.Infrastructure.Data;


namespace SaborFast.Infrastructure.Repositories;


public class RestauranteRepository : BaseRepository<Restaurante>, IRestauranteRepository
{
    public RestauranteRepository(SaborFastDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Restaurante>> GetByCategoriaAsync(string categoria)
    {
        return await _dbSet
            .Where(r => r.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<IEnumerable<Restaurante>> GetByNomeAsync(string nome)
    {
        return await _dbSet
            .Where(r => r.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<bool> ExistsByNomeAsync(string nome)
    {
        return await _dbSet
            .AnyAsync(r => r.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    }

    public async Task<Restaurante?> GetWithCardapioAsync(int id)
    {
        return await _dbSet
            .Include(r => r.CardapioItens)
            .FirstOrDefaultAsync(r => r.Id == id);
    } 
}