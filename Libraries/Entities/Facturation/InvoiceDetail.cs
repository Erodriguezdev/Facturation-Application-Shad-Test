using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Facturation;

public class InvoiceDetail
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int InvoiceId { get; set; }
    [Required]
    public int Qty { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public decimal TotalItbis { get; set; }
    [Required]
    public decimal SubTotal { get; set; }
    [Required]
    public decimal Total { get; set; }

    // Relations
    public Invoice Invoice { get; set; } = null!;
}
