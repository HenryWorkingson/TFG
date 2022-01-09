using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class DTOTarjeta
    {
        public string Numero_Tarjeta { get; set; }
        public string FechaCadu_Tarjeta { get; set; }
        public string Nom_Propietario { get; set; }
    }
}
