using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idReserva { get; set; }
        public string reservaNombre { get; set;}
        public int numeroPersonas { get; set; }
        public string reservaTelefono { get; set; }
        public string reservaDate { get; set; }
        public string reservaTime { get; set; }
    }
}
