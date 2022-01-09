using System;

namespace WebMVC.DTOS
{
    public class DTOReserva
    {
        public string reservaNombre { get; set; }
        public int numeroPersonas { get; set; }
        public string reservaTelefono { get; set; } 
        public string reservaDate { get; set; }
        public string reservaTime { get; set; }
    }
}
