using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class DTOPedido
    {
        public string Descripcion_Pedido { get; set; }
        public int Tarjeta { get; set; }
        public int Id_Direccion { get; set; }
        public double Precio_Total { get; set; }

        public string Nombre_Direccion { get; set; }
        public string Provincia { get; set; }
        public string Municipal { get; set; }
        public string DNI_Cliente_Rceiv { get; set; }
        public string Nombre_Cliente_Rec { get; set; }
        public string Telefono_Cliente { get; set; }

        public string Numero_Tarjeta { get; set; }
        public string FechaCadu_Tarjeta { get; set; }
        public string Nom_Propietario { get; set; }
    }
}
