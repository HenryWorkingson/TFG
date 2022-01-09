using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteFunciones
{
    [Table("LineaPedidos")]
    public class LineaPedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_LineaPedido { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int id_Plato { get; set; }
        public int id_Pedido { get; set; }
        public int Cantidad { get; set; }
        public double PrecioProductoUnitario { get; set; }
        public double PrecioTotal { get; set; }
        // precio, importe total, cantidad y etc...
        public List<Plato> Lista_Pedidos { get; set; }
    }
}
