using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    [Table("Platos")]
    public class Plato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string NombrePlato { get; set; }
        public string DescripcionPlato { get; set; }
        public double PrecioBase { get; set; }
        public string TipoPlato { get; set; }
        public string ImagePath { get; set; }
    }
}
