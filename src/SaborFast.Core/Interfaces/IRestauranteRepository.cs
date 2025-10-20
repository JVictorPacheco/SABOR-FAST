using SaborFast.Core.Entities;

namespace SaborFast.Core.Interfaces;


/// <summary>
  /// Interface específica para operações do repositório de Restaurante.
  /// Herda operações básicas do IRepository e adiciona métodos específicos do domínio.
  /// </summary>
public interface IRestauranteRepository : IRepository<Restaurante>
{
    /// <summary>
    /// Busca restaurantes por categoria específica.
    /// </summary>
    // <param name="categoria">Nome da categoria para filtrar</param>
    /// <returns>Lista de restaurantes da categoria especificada</returns>
    Task<IEnumerable<Restaurante>> GetByCategoriaAsync(string categoria);


    /// <summary>
    /// Busca restaurantes que contenham o termo no nome (busca parcial).
    /// </summary>
    // <param name="nome">Termo para buscar no nome do restaurante</param>
    /// <returns>Lista de restaurantes que contenham o termo no nome</returns>
    Task<IEnumerable<Restaurante>> GetByNomeAsync(string nome);


    /// <summary>
    /// Verifica se existe um restaurante com o nome exato especificado.
    /// </summary>
    // <param name="nome">Nome exato do restaurante</param>
    /// <returns>True se existe, False se não existe</returns>
    Task<bool> ExistsByNomeAsync(string nome);





}

