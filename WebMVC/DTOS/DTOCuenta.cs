using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class DTOCuenta
    {
        public string Nombre_Cuenta { get; set; }
        public string Apellido_Cuenta { get; set; }
        public string Password_Cuenta { get; set; }
        public string Correo_Cuenta { get; set; }

    }
}
