using System.ComponentModel.DataAnnotations; //O que eu vou usar externamente



namespace SaborFast.Core.Entities; //Caminho do arquivos atual


/// <summary>
/// Entidade que representa um restaurante do sistema.
/// Relacionamento 1:N com CardapioItem.
/// </summary>
public class Restaurante : BaseEntity
{

    /// <summary>Nome do restaurante (obrigatório, máx. 255 caracteres)</summary>
    [Required]
    [StringLength(255)]
    public string Nome { get; set; } = string.Empty;


   /// <summary>Categoria do restaurante (opcional, máx. 100 caracteres)</summary> 
    [StringLength(100)]
    public string? Categoria { get; set; }

    /// <summary>
      /// Coleção de itens do cardápio deste restaurante.
      /// Lazy Loading habilitado - carrega quando acessada.
      /// </summary>
    public virtual ICollection<CardapioItem> CardapioItens
    {
        get; set;
    } = new List<CardapioItem>(); // Coleção de itens que pertecem a 1 restaurante


}