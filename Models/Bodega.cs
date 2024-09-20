using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace induccionef.Models;

public class Bodega
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BodegaId { get; set; }
    public string Name {get; set;}
    public string Description {get; set;}

    //public ICollection<Product> Products {get; set;} = new List<Product>();
}