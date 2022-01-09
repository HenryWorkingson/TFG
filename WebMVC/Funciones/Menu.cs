using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class Menu
    {

        protected AplicationDbContext _context;
        public Menu(AplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateMenu(DTOMenu produc)
        {
            global::Restaurante.Menu miProduc = new global::Restaurante.Menu()
            {
                DescripcionMenu = produc.DescripcionMenu,
                NombreMenu = produc.NombreMenu,
                PrecioMenu = produc.PrecioMenu
            };
            _context.Menus.Add(miProduc);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarMenuConsola()
        {
            var list = _context.Menus;
            foreach (var ani in list)
            {
                Console.Write(ani.IdMenu + " ");
                Console.Write(ani.NombreMenu + " ");
                Console.Write(ani.DescripcionMenu + " ");
                Console.WriteLine(ani.PrecioMenu);
            }
        }
        //buqueda con el id_Animal para devolver a una animal especifico
        public void listarIdMenu(int id)
        {
            var q = _context.Menus.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.IdMenu + " ");
                Console.Write(q.NombreMenu + " ");
                Console.Write(q.DescripcionMenu + " ");
                Console.WriteLine(q.PrecioMenu);
            }
        }
        public void upDateMenus(int id, DTOMenu proct)
        {
            var q = _context.Menus.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.NombreMenu = proct.NombreMenu;
                q.DescripcionMenu = proct.DescripcionMenu;
                q.PrecioMenu = proct.PrecioMenu;
                listarIdMenu(id);
            }
            _context.SaveChanges();
        }
        public bool EliminarMenus(int id)
        {
            var q = _context.Menus.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Menus.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
        
        
    }
}
