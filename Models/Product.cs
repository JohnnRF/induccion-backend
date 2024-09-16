using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}
