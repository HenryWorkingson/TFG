using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    [Table("Cuentas")]
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_Cuenta { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre_Cuenta { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido_Cuenta { get; set; }
        public string Password_Cuenta { get; set; }
        public string Correo_Cuenta { get; set; }

    }
}
