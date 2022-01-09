using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class Pedido
    {
        List<global::Restaurante.LineaPedido> carro;
        protected AplicationDbContext _context;
        public Pedido (AplicationDbContext context)
        {
            _context = context;
        }
        public bool CreatePedido(DTOPedido p)
        {
            carro = new List<global::Restaurante.LineaPedido>();
            global::Restaurante.Pedido miPedido = new global::Restaurante.Pedido()
            {
                Descripcion_Pedido = p.Descripcion_Pedido,
                Tarjeta = p.Tarjeta,
                Precio_Total = p.Precio_Total,
                Id_Direccion = p.Id_Direccion,
            };
            //loadCarro(miPedido.id_Pedido);
            _context.Pedidos.Add(miPedido);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarPedidoConsola()
        {
            var list = _context.Pedidos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Pedido + " ");
                Console.Write(ani.Descripcion_Pedido + " ");
                Console.Write(ani.Id_Direccion + " ");
                Console.Write(ani.Tarjeta + " ");
                Console.WriteLine(ani.Precio_Total);
            }
        }
        public void listarLineasProducto()
        {
            foreach (var proc in carro)
            {
                Console.Write(proc.id_LineaPedido + " ");
                Console.Write(proc.Cantidad + " ");
                Console.Write(proc.id_Pedido + " ");
                Console.Write(proc.PrecioProductoUnitario + " ");
                Console.Write(proc.PrecioTotal + " ");
                Console.WriteLine(proc.id_Plato);
            }
        }
        public void listarIdPedido(int id)
        {
            var q = _context.Pedidos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_Pedido + " ");
                Console.Write(q.Descripcion_Pedido + " ");
                Console.Write(q.Id_Direccion + " ");
                Console.Write(q.Tarjeta + " ");
                Console.WriteLine(q.Precio_Total);
            }
        }
        public void upDatePedido(int id, DTOPedido p)
        {
            var q = _context.Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Descripcion_Pedido = p.Descripcion_Pedido;
                q.Id_Direccion = p.Id_Direccion;
                q.Tarjeta = p.Tarjeta;
                q.Precio_Total = p.Precio_Total;
            }
            _context.SaveChanges();
        }
        public bool EliminarPedido(int id)
        {
            var q = _context.Pedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.Pedidos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
        public void addLineaProducto(global::Restaurante.LineaPedido p)
        {
            _context.LineaPedidos.Add(p);
            carro.Add(p);
        }
        public void eliminarLineaProducto(global::Restaurante.LineaPedido p)
        {
            foreach (var q in carro)
            {
                if (q.Equals(p))
                    carro.Remove(p);
                _context.LineaPedidos.Remove(p);
            }
        }


        public List<global::Restaurante.LineaPedido> getCarro()
        {
            return carro;
        }
        public void mostrarCarro(int idPedido)
        {
            var p = _context.Pedidos.Find(idPedido);
            if (p == null || p.lineas == null)
                if (p == null)
                    Console.WriteLine("perdido1");
                else
                    Console.WriteLine("perdido2");
            else
            {
                foreach (var q in p.lineas)
                {
                    Console.Write(q.id_LineaPedido + " ");
                    Console.Write(q.Cantidad + " ");
                    Console.Write(q.id_Pedido + " ");
                    Console.Write(q.PrecioProductoUnitario + " ");
                    Console.Write(q.PrecioTotal + " ");
                    Console.WriteLine(q.id_Plato);
                }
            }
        }
        public global::Restaurante.Pedido ultimoPedido()
        {
            var list = _context.Pedidos;
            global::Restaurante.Pedido q = null;
            foreach (var ani in list)
            {
                if (ani != null)
                {
                    Console.Write(ani.id_Pedido + " ");
                    Console.Write(ani.Descripcion_Pedido + " ");
                    Console.Write(ani.Id_Direccion + " ");
                    Console.Write(ani.Tarjeta + " ");
                    Console.WriteLine(ani.Precio_Total);
                    q = ani;
                }
            }
            return q;
        }

    }
}
