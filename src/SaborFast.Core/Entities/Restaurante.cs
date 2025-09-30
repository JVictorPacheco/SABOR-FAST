using System.ComponentModel.DataAnnotations; //O que eu vou usar externamente



namespace SaborFast.Core.Entities; //Caminho do arquivos atual


public class Restaurante : BaseEntity
{
    [Required]
    [StringLength(255)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Categoria { get; set; }


    public virtual ICollection<CardapioItem> CardapioItens
    {
        get; set;
    } = new List<CardapioItem>(); // Coleção de itens que pertecem a 1 restaurante


}