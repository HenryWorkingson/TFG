using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class Tarjeta
    {
        protected AplicationDbContext _context;
        public Tarjeta(AplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateTarjetaPago(DTOTarjeta tar)
        {
            global::Restaurante.Tarjeta miTar = new global::Restaurante.Tarjeta()
            {
                Numero_Tarjeta = tar.Numero_Tarjeta,
                Nom_Propietario = tar.Nom_Propietario,
                FechaCadu_Tarjeta = tar.FechaCadu_Tarjeta,
            };
            _context.Tarjetas.Add(miTar);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarTarjetaPagoConsola()
        {
            var list = _context.Tarjetas;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Tarjeta + " ");
                Console.Write(ani.Numero_Tarjeta + " ");
                Console.Write(ani.Nom_Propietario + " ");
                Console.WriteLine(ani.FechaCadu_Tarjeta + " ");
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdTarjetaPago(int id)
        {
            var ani = _context.Tarjetas.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_Tarjeta + " ");
                Console.Write(ani.Numero_Tarjeta + " ");
                Console.Write(ani.Nom_Propietario + " ");
                Console.WriteLine(ani.FechaCadu_Tarjeta + " ");
            }
        }
        public void upDateTarjetaPago(int id, DTOTarjeta tar)
        {
            var q = _context.Tarjetas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Numero_Tarjeta = tar.Numero_Tarjeta;
                q.Nom_Propietario = tar.Nom_Propietario;
                q.FechaCadu_Tarjeta = tar.FechaCadu_Tarjeta;
            }
            _context.SaveChanges();
        }
        public bool EliminarTarjetaPago(int id)
        {
            var q = _context.Tarjetas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Tarjetas.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
