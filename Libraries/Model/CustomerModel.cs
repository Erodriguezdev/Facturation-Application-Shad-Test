using System.ComponentModel.DataAnnotations;

namespace Shared;

public class CustomerModel
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Campo es requerido")]
    [StringLength(70, ErrorMessage ="Ha excedido el numero de caracteres")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Campo es requerido")]
    [StringLength(70, ErrorMessage = "Ha excedido el numero de caracteres")]
    public string Address { get; set; } = null!;
    [Required(ErrorMessage = "Campo es requerido")]
    public bool Status { get; set; }
    [Required(ErrorMessage = "Campo es requerido")]
    public int TypeCustomerId { get; set; }
    public string? TypeCustomer { get; set; }
}
