using Microsoft.EntityFrameworkCore; // Para operações async do EF Core (.Include, .ToListAsync,etc.)
using SaborFast.Core.Entities;
using SaborFast.Core.Interfaces;
using SaborFast.Infrastructure.Data;

namespace SaborFast.Infrastructure.Repositories;

/// <summary>
/// Repository específico para operações com CardapioItem.
/// Implementa padrões SOLID:
/// - SRP: Responsabilidade única para operações de CardapioItem
/// - OCP: Aberto para extensão via herança, fechado para modificação
/// - LSP: Substitui corretamente BaseRepository e implementa ICardapioItemRepository
/// - ISP: Interface segregada com métodos específicos do domínio
/// - DIP: Depende de abstrações (ICardapioItemRepository) não de implementações
/// </summary>
/// <remarks>
/// Herda CRUD básico do BaseRepository<CardapioItem> e adiciona métodos específicos de negócio.
/// Segue Clean Code com métodos pequenos, nomes descritivos e responsabilidades bem definidas.
/// </remarks>



public class CardapioItemRepository : BaseRepository<CardapioItem>, ICardapioItemRepository
{
    /// <summary>
    /// Construtor que injeta dependência do DbContext.
    /// Principio DIP: Recebe abstração (SaborFastDbContext) via injeção de dependência.
    /// O ": base(context)" delega inicialização para classe pai BaseRepository.
    /// </summary>
    /// <param name="context">Contexto do Entity Framework para acesso ao banco</param>
    public CardapioItemRepository(SaborFastDbContext context) : base(context)
    { }

    /// <summary>
    /// Busca todos os itens de cardápio de um restaurante específico.
    /// Clean Code: Nome descritivo, método pequeno com responsabilidade única.
    /// Performance: Usa índice da chave estrangeira RestauranteId.
    /// </summary>
    /// <param name="restauranteId">ID do restaurante para filtrar itens</param>
    /// <returns>Lista assíncrona de itens do cardápio do restaurante especificado</returns>

    public async Task<IEnumerable<CardapioItem>> GetByRestauranteIdAsync(int restauranteId)
    {
        return await _dbSet
            .Where(item => item.RestauranteId == restauranteId)
            .OrderBy(item => item.Item)
            .ToListAsync();
    }


    /// <summary>
    /// Busca itens do cardápio dentro de uma faixade preço (inclusive).
    /// Clean Code: Parâmetros claros, lógica simples e direta.
    /// Business Logic: Filtro útil para busca de itens por orçamento.
    /// </summary>
    /// <param name="precoMinimo">Preço mínimo (inclusive) para filtrar</param>
    /// <param name="precoMaximo">Preço máximo  (inclusive) para filtrar</param>
    /// <returns>Lista assíncrona de itens dentro da faixa de preço especificada</returns>

    public async Task<IEnumerable<CardapioItem>> GetByFaixaPrecoAsync
    (decimal precoMinimo, decimal precoMaximo)
    {
        return await _dbSet
            .Where(item => item.Price >= precoMinimo && item.Price <= precoMaximo) // Filtro por faixa
            .OrderBy(item => item.Price)
            .ToListAsync();
    }


    /// <summary>
    /// Busca itens que contenham o termo especificado no nome (busca parcial case-insensitive).
    /// Clean Code: Nome autoexplicativo, implementação simples.
    /// UX: Busca flexível que encontra correspondências parciais.
    /// </summary>
    /// <param name="nome">Termo para buscar no nome do item (case-insensitive)</param>
    /// <returns>Lista assíncrona de itens cujo nome contém o termo especificado</returns>

    public async Task<IEnumerable<CardapioItem>> GetByNomeAsync(string nome)
    {

        if (string.IsNullOrWhiteSpace(nome))
            return Enumerable.Empty<CardapioItem>(); // Retorna lista vazia se o termo for nulo ou vazio
        

        return await _dbSet
            .Where(item => item.Item.Contains(nome, StringComparison.OrdinalIgnoreCase))
            .OrderBy(item => item.Item)
            .ToListAsync();
    }


    /// <summary>
    /// Busca itens disponíveis de um restaurante específico.
    /// Business Logic: Assumindo que items com Description != null são considerados disponíveis.
    /// Clean Code: Método específico para regra de negócio clara.
    /// </summary>
    /// <param name="restauranteId">ID do restaurante para filtrar itens disponíveis</param>
    /// <returns>Lista assíncrona de itens disponíveis do restaurante especificado</returns>
    /// <remarks>
    /// Critério de disponibilidade: itens com Description preenchida são considerados ativos/disponíveis.
    /// Esta lógica pode ser ajustada conforme regras de negócio específicas (ex: campo IsActive).
    /// </remarks>

    public async Task<IEnumerable<CardapioItem>> GetDisponivelByRestauranteAsync(int restauranteId)
    {
        return await _dbSet
           .Where(item => item.RestauranteId == restauranteId && !string.IsNullOrWhiteSpace(item.Description))
           .OrderBy(item => item.Item)
           .ToListAsync();
    }

    /// <summary>
      /// Conta quantos itens existem no cardápio de um restaurante.
      /// Performance: Usa CountAsync (não carrega dados, só conta no banco).
      /// Clean Code: Método específico, nome claro, responsabilidade única.
      /// </summary>
      /// <param name="restauranteId">ID do restaurante para contar itens</param>
    /// <returns>Número total de itens no cardápio do restaurante especificado</returns>

    public async Task<int> CountByRestauranteAsync(int restauranteId)
    {   
        return await _dbSet
            .CountAsync(item => item.RestauranteId == restauranteId);


    }
}

