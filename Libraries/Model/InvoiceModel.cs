using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public class InvoiceModel
{
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
   
    public decimal? TotalItbis { get; set; }
 
    public decimal? SubTotal { get; set; }
    
    public decimal? Total { get; set; }

    public List<InvoiceDetailModel>? InvoiceDetailModels { get; set; }
}
