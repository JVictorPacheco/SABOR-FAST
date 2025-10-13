using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SaborFast.Core.Entities;

/// <summary>
  /// Representa um item do cardápio de um restaurante.
  /// Entidade que armazena informações sobre pratos, bebidas ou produtos oferecidos.
  /// </summary>
  /// <remarks>
  /// Esta entidade possui relacionamento N:1 com Restaurante (muitos itens para um restaurante).
  /// Herda de BaseEntity, obtendo Id, CreatedAt e UpdatedAt automaticamente.
  /// 
  /// Relacionamentos:
  /// - RestauranteId: Chave estrangeira para a tabela Restaurantes
  /// - Restaurante: Propriedade de navegação com Lazy Loading habilitado
  /// </remarks>


public class CardapioItem : BaseEntity
{

    /// <summary>
    /// Identificador do restaurante ao qual este item pertence.
    /// Chave estrangeira obrigatória para a tabela Restaurantes.
    /// </summary>
    [Required]
    public int RestauranteId { get; set; }


    /// <summary>
    /// Nome do item do cardápio (ex: "Pizza Margherita", "Coca-Cola 350ml").
    /// Campo obrigatório com limite máximo de 255 caracteres.
    /// </summary>
    [Required]
    [StringLength(255)]
    public string Item { get; set; } = string.Empty;


     /// <summary>
    /// Preço do item em formato decimal com precisão de 10 dígitos e 2 casas decimais.
    /// Valores possíveis: 0.01 até 99999999.99
    /// Campo obrigatório.
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }


    /// <summary>
    /// Descrição detalhada do item (ingredientes, modo de preparo, etc).
    /// Campo opcional, pode ser null.
    /// </summary>
    public string Description { get; set; }



/// <summary>
    /// Propriedade de navegação para o restaurante associado a este item.
    /// Utiliza Lazy Loading (virtual) - carrega automaticamente quando acessada.
    /// Permite navegar do item para seus dados do restaurantesem consultas manuais.
    /// </summary>
    /// <remarks>
    /// O Entity Framework preenche automaticamente esta propriedade baseado no RestauranteId.
    /// null! suprime warnings do compilador - o EF garante que não será null em runtime.
    /// </remarks>
    public virtual Restaurante Restaurante { get; set; } = null!; // Item que pertece a 1 restaurante



}