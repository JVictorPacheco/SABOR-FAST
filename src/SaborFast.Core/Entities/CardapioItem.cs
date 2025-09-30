using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SaborFast.Core.Entities;

public class CardapioItem : BaseEntity
{
    [Required]
    public int RestauranteId { get; set; }

    [Required]
    [StringLength(255)]
    public string Item { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public string Description { get; set; }

    public virtual Restaurante Restaurante { get; set; } = null!; // Item que pertece a 1 restaurante
    


}