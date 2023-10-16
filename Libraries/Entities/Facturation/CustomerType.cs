using System.ComponentModel.DataAnnotations;

namespace Models.Facturation;

public class CustomerType
{
    public int Id { get; set; }
    [StringLength(70, ErrorMessage = "Limits of caracters is 70")]
    public string Description { get; set; } = null!;

    public IEnumerable<Customers> Customers { get; set; } = null!;
}
