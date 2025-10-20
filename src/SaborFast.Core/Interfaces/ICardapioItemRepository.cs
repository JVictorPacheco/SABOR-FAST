using SaborFast.Core.Entities;


namespace SaborFast.Core.Interfaces;

/// <summary>
/// Interface específica para operações do repositório de CardapioItem.
/// Herda operações básicas do IRepository e adiciona métodos específicos do domínio.
/// </summary>
public interface ICardapioItemRepository : IRepository<CardapioItem>
{

    /// <summary>
    /// Busca todos os itens de cardápio de um restaurante específico.
    /// </summary>
    // <param name="restauranteId">ID do restaurante</param>
    /// <returns>Lista de itens do cardápio do restaurante</returns>
    Task<IEnumerable<CardapioItem>> GetByRestauranteIdAsync(int restauranteId);


    /// <summary>
    /// Busca itens do cardápio por faixa de preço.
    /// </summary>
    // <param name="precoMinimo">Preço mínimo (inclusive)</param>
    // <param name="precoMaximo">Preço máximo (inclusive)</param>
    /// <returns>Lista de itens dentro da faixa de preço</returns>
    Task<IEnumerable<CardapioItem>> GetByFaixaPrecoAsync(decimal precoMinimo, decimal precoMaximo);




    /// <summary>
    /// Busca itens do cardápio que contenham o termo no nome (busca parcial).
    /// </summary>
    // <param name="nome">Termo para buscar no nome do item</param>
    /// <returns>Lista de itens que contenham o termo no nome</returns>
    Task<IEnumerable<CardapioItem>> GetByNomeAsync(string nome);


    /// <summary>
    /// Busca itens disponíveis (ativos) de um restaurante específico.
    /// </summary>
    // <param name="restauranteId">ID do restaurante</param>
    /// <returns>Lista de itens disponíveis do restaurante</returns>
    Task<IEnumerable<CardapioItem>> GetDisponivelByRestauranteAsync(int restaurenteId);



    /// <summary>
    /// Conta quantos itens existem no cardápio de um restaurante.
    /// </summary>
    // <param name="restauranteId">ID do restaurante</param>
    /// <returns>Número total de itens no cardápio</returns>
    Task<int> CountByRestauranteAsync(int restauranteId);




}