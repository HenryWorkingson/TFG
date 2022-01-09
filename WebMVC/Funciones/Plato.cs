using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class Plato
    {
        protected AplicationDbContext _context;
        public Plato(AplicationDbContext context)
        {
            _context = context;
        }
        public bool CreatePlato(DTOPlato produc)
        {
            global::Restaurante.Plato miPlato = new global::Restaurante.Plato()
            {
                DescripcionPlato = produc.DescripcionPlato,
                NombrePlato = produc.NombrePlato,
                PrecioBase = produc.PrecioBase,
                TipoPlato=produc.TipoPlato,
            };
            _context.Platos.Add(miPlato);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarPlatoConsola()
        {
            var list = _context.Platos;
            foreach (var ani in list)
            {
                Console.Write(ani.IdProducto + " ");
                Console.Write(ani.NombrePlato + " ");
                Console.Write(ani.DescripcionPlato + " ");
                Console.Write(ani.TipoPlato + " ");
                Console.WriteLine(ani.PrecioBase);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdPlato(int id)
        {
            var q = _context.Platos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.IdProducto + " ");
                Console.Write(q.NombrePlato+ " ");
                Console.Write(q.DescripcionPlato + " ");
                Console.Write(q.TipoPlato + " ");
                Console.WriteLine(q.PrecioBase);
            }
        }
        public void upDatePlato(int id, DTOPlato proct)
        {
            var q = _context.Platos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.NombrePlato = proct.NombrePlato;
                q.DescripcionPlato = proct.DescripcionPlato;
                q.PrecioBase = proct.PrecioBase;
                q.TipoPlato = proct.TipoPlato;
                listarIdPlato(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarPlato(int id)
        {
            var q = _context.Platos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Platos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
