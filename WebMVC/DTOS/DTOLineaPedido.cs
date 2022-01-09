using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class DTOLineaPedido
    {
        public int id_Plato { get; set; }
        public int id_Pedido { get; set; }
        public int Cantidad { get; set; }
        public double PrecioProductoUnitario { get; set; }
        public double PrecioTotal { get; set; }
        // precio, importe total, cantidad y etc...
        public List<DTOPlato> Lista_Pedidos { get; set; }
    }
}
