using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace induccionef.Models;

public class Product{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [MaxLength(45)]
    public string Name { get; set;}

    public decimal Price { get; set;}

    public int Stock { get; set;}

    public bool Active { get; set;}

    public int BodegaId {get; set;}

    [ForeignKey("BodegaId")]
    [JsonIgnore]
    public Bodega? bodega{ get; set;}    
}
