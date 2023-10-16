using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public class InvoiceDetailModel
{
    public int Id { get; set; }
   
    public int? InvoiceId { get; set; }
    [Required]
    public int Qty { get; set; }
    [Required]
    public decimal Price { get; set; }
  
    public decimal? TotalItbis { get; set; }
    
    public decimal? SubTotal { get; set; }
    public decimal? Total { get; set; }
}
