using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class DTOPlato
    {
        public string NombrePlato { get; set; }
        public string DescripcionPlato { get; set; }
        public double PrecioBase { get; set; }
        public string TipoPlato { get; set; }
        public string ImagePath { get; set; }
    }
}
