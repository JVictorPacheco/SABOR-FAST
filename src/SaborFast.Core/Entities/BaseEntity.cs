namespace SaborFast.Core.Entities;


/// <summary>
/// Classe base abstrata que define propriedades comuns para todas as entidades do domínio.
/// Fornece identificação única, controle de auditoria e timestamps automáticos.
/// </summary>
/// <remarks>
/// Esta classe não pode ser instanciada diretamente (abstract).
/// Todas as entidades de domínio devem herdar desta classe 
///  para garantir consistência.
/// Propriedades fornecidas:
/// - Id: Chave primária única
/// - CreatedAt: Data/hora de criação (UTC)
/// - UpdatedAt: Data/hora da última atualização (nullable)
/// </remarks>


public abstract class BaseEntity
{
    /// <summary>
    ///  Identificador único da entidade. Chave primária no 
    ///  banco de dados.
    ///  </summary>
    public int Id { get; set; }


    /// <summary>
      /// Data e hora de criação do registro em UTC.
      /// Valor padrão: momento atual da criação da instância.
      /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    /// <summary>
      /// Data e hora da última atualização do registro em UTC.
      /// Null quando o registro nunca foi atualizado após a criação.
      /// </summary>
    public DateTime? UpdatedAt { get; set; }
}