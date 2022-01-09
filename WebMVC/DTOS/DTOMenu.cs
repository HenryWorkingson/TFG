using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class DTOMenu
    {
        public string NombreMenu { get; set; }
        public string DescripcionMenu { get; set; }
        public double PrecioMenu { get; set; }
    }
}
