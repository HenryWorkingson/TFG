using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Pedido { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Descripcion_Pedido { get; set; }
        public int Tarjeta { get; set; }
        public int Id_Direccion { get; set; }
        public double Precio_Total { get; set; }
        public ICollection<LineaPedido> lineas { get; set; }
    }
}
