using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteFunciones
{
    [Table("Menus")]
    public class Menu
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMenu { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string NombreMenu { get; set; }
        public string DescripcionMenu { get; set; }
        public double PrecioMenu { get; set; }
    }
}
