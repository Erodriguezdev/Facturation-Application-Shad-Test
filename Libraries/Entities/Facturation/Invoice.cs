using System.ComponentModel.DataAnnotations;

namespace Models.Facturation;

public class Invoice
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public decimal TotalItbis { get; set; }
    [Required]
    public decimal SubTotal { get; set; }
    [Required]
    public decimal Total { get; set; }

    //Relation
    public Customers Customer { get; set; } = null!;
    public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; } = null!;
}
