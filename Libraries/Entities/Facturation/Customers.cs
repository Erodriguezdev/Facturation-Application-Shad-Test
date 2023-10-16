using System.ComponentModel.DataAnnotations;

namespace Models.Facturation;

public class Customers
{
    public int Id { get; set; }
    [Required]
    [StringLength(70, ErrorMessage = "Limits of caracters is 70")]
    public string CustName { get; set; } = null!;
    [Required]
    [StringLength(120, ErrorMessage = "Limits of caracters is 70")]
    public string Address { get; set; } = null!;
    [Required]
    public bool Status { get; set; }
    [Required]
    public int CustomerTypeId { get; set; }


    public CustomerType CustomerType { get; set; } = null!;
}
