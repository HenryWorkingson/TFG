using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class Direccion_Envio
    {
        protected AplicationDbContext _context;
        public Direccion_Envio(AplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateDireccion_Envio(DTODireccion_Envio dir)
        {
            global::Restaurante.Direccion_Envio miDE = new global::Restaurante.Direccion_Envio()
            {
                Nombre_Direccion = dir.Nombre_Direccion,
                Nombre_Cliente_Rec = dir.Nombre_Cliente_Rec,
                Provincia = dir.Provincia,
                Municipal = dir.Municipal,
                DNI_Cliente_Rceiv = dir.DNI_Cliente_Rceiv,
                Telefono_Cliente = dir.Telefono_Cliente,
            };
            _context.DireccionEnvios.Add(miDE);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarDireccion_EnvioConsola()
        {
            var list = _context.DireccionEnvios;
            foreach (var ani in list)
            {
                Console.Write(ani.id_DireccionEnvio + " ");
                Console.Write(ani.Nombre_Direccion + " ");
                Console.Write(ani.Provincia + " ");
                Console.Write(ani.Municipal + " ");
                Console.Write(ani.DNI_Cliente_Rceiv + " ");
                Console.WriteLine(ani.Nombre_Cliente_Rec + " ");
                Console.WriteLine(ani.Telefono_Cliente + " ");
            }
        }
        //buqueda con el id_dir para devolver a una dir especifico
        public void listarIdDireccion_Envio(int id)
        {
            var ani = _context.DireccionEnvios.Find(id);
            //var q = (from u in db.dirs select u).ToList();
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_DireccionEnvio + " ");
                Console.Write(ani.Nombre_Direccion + " ");
                Console.Write(ani.Provincia + " ");
                Console.Write(ani.Municipal + " ");
                Console.Write(ani.DNI_Cliente_Rceiv + " ");
                Console.WriteLine(ani.Nombre_Cliente_Rec + " ");
                Console.WriteLine(ani.Telefono_Cliente + " ");
            }
        }
        public void upDateDireccion_Envio(int id, DTODireccion_Envio dir)
        {
            var q = _context.DireccionEnvios.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Direccion = dir.Nombre_Direccion;
                q.Provincia = dir.Provincia;
                q.Municipal = dir.Municipal;
                q.DNI_Cliente_Rceiv = dir.DNI_Cliente_Rceiv;
                q.Nombre_Cliente_Rec = dir.Nombre_Cliente_Rec;
                q.Telefono_Cliente=dir.Telefono_Cliente;
            }
            _context.SaveChanges();
        }
        public bool EliminarDireccion_Envio(int id)
        {
            var q = _context.DireccionEnvios.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.DireccionEnvios.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
