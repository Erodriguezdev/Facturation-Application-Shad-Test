using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DetailModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Los valores deben ser de 1 en adelante")]
        public int Qty { get; set; }
        public decimal price { get; set; }   

    }
}

