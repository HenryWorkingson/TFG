using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteFunciones
{
    [Table("Tarjetas")]
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Tarjeta { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Numero_Tarjeta { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string FechaCadu_Tarjeta { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Nom_Propietario { get; set; }
    }
}
