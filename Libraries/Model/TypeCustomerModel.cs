
using System.ComponentModel.DataAnnotations;

namespace Shared;

public class TypeCustomerModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(70,ErrorMessage = "Ha Superado el Limite de caracteres")]
    public string Description { get; set; } = null!;
}
