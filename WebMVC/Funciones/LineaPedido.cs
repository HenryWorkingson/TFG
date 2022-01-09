using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC
{
    public class LineaPedido
    {
        protected AplicationDbContext _context;
        public LineaPedido(AplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateLinea_Pedido(DTOLineaPedido c)
        {
            global::Restaurante.LineaPedido miLinea = new global::Restaurante.LineaPedido()
            {
                id_Plato = c.id_Plato,
                id_Pedido = c.id_Pedido,
                Cantidad = c.Cantidad,
                PrecioProductoUnitario = c.PrecioProductoUnitario,
                PrecioTotal = c.PrecioTotal
            };
            _context.LineaPedidos.Add(miLinea);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarLineaPedidoConsola()
        {
            var list = _context.LineaPedidos;
            foreach (var ani in list)
            {
                Console.Write(ani.id_LineaPedido + " ");
                Console.Write(ani.Cantidad + " ");
                Console.Write(ani.id_Pedido + " ");
                Console.Write(ani.PrecioProductoUnitario + " ");
                Console.Write(ani.PrecioTotal + " ");
                Console.WriteLine(ani.id_Plato);
            }
        }
        public void listarIdLineaPedido(int id)
        {
            var q = _context.LineaPedidos.Find(id);
            //var q = (from u in db.Animals select u).ToList();
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(q.id_LineaPedido + " ");
                Console.Write(q.Cantidad + " ");
                Console.Write(q.id_Pedido + " ");
                Console.Write(q.PrecioProductoUnitario + " ");
                Console.Write(q.PrecioTotal + " ");
                Console.WriteLine(q.id_Plato);
            }
        }
        public void upDateLineaPedido(int id, DTOLineaPedido Op)
        {
            var q = _context.LineaPedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.id_Plato = Op.id_Plato;
                q.id_Pedido = Op.id_Pedido;
                q.Cantidad = Op.Cantidad;
                q.PrecioProductoUnitario = Op.PrecioProductoUnitario;
                q.PrecioTotal = Op.PrecioTotal;
            }
            _context.SaveChanges();
        }
        public bool EliminarLineaPedido(int id)
        {
            var q = _context.LineaPedidos.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); return false; }
            else
            {
                _context.LineaPedidos.Remove(q);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
