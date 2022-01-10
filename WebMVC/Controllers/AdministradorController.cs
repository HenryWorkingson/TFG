using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.DTOS;

namespace WebMVC.Controllers
{
    
    public class AdministradorController : Controller
    {
        protected AplicationDbContext db;
        public AdministradorController (AplicationDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        [Route("Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
        //-----------------------------------------------------------Cuenta---------------------------------------------------
        [HttpGet]
        [Route("Admin/Cuentas")]
        public IActionResult getCuentas()
        {
            var q = db.Cuentas.Select(u => u).ToList();
            return Ok(q);
        }
        [HttpDelete]
        [Route("Admin/DeleteCuenta/{id:int}")]
        public IActionResult DeleteCuenta(int id)
        {
            global::Restaurante.Cuenta p = db.Cuentas.Find(id);
            if (p != null)
            {
                db.Cuentas.Remove(p);
                db.SaveChanges();
            }//RedirectToAction("getCuentas")
            return Ok(200);
        }
        [HttpGet]
        [Route("Admin/CrearCuenta")]
        public IActionResult CrearCuenta()
        {
            return View();
        }
        [HttpPost]
        [Route("Admin/CrearCuenta")]
        public IActionResult CrearCuenta([FromBody] DTOCuenta c)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                global::Restaurante.Cuenta miUsuario = new global::Restaurante.Cuenta()
                {
                    Nombre_Cuenta = c.Nombre_Cuenta,
                    Apellido_Cuenta = c.Apellido_Cuenta,
                    Password_Cuenta = c.Password_Cuenta,
                    Correo_Cuenta = c.Correo_Cuenta,
                };

                db.Cuentas.Add(miUsuario);
                db.SaveChanges();
                return Ok(200);
            }
            return View();
        }
        //--------------------------------------------Pedidos---------------------------------------------------
        [HttpGet]
        [Route("Admin/Pedidos")]
        public IActionResult Pedidos()
        {
            var q = db.Pedidos.Select(u => u).ToList();
            return Ok(q);
        }
        [HttpDelete]
        [Route("Admin/DeletePedido/{id:int}")]
        public IActionResult DeletePedido(int id)
        {
            global::Restaurante.Pedido p = db.Pedidos.Find(id);
            if (p != null && p.Id_Direccion != 0 && p.Tarjeta != 0)
            {
                global::Restaurante.Direccion_Envio dir = db.DireccionEnvios.Find(p.Id_Direccion);
                db.DireccionEnvios.Remove(dir);
                global::Restaurante.Tarjeta tar = db.Tarjetas.Find(p.Id_Direccion);
                db.Tarjetas.Remove(tar);

                var q = db.LineaPedidos.Select(u => u).ToList();
                foreach (var a in q)
                {
                    if (a.id_Pedido.Equals(id))
                        db.LineaPedidos.Remove(a);
                }

                db.Pedidos.Remove(p);
                db.SaveChanges();
            }
            else
            {
                db.Pedidos.Remove(p);
                db.SaveChanges();
            }

            return Ok(200);
        }
        //--------------------------------------------Tarjetas----------------------------------------------------

        [HttpGet]
        [Route("Admin/Tarjetas")]
        public IActionResult Tarjetas()
        {
            var q = db.Tarjetas.Select(u => u).ToList();
            return Ok(q);
        }
        //--------------------------------------------Direccion---------------------------------------------------
        [HttpGet]
        [Route("Admin/Direcciones")]
        public IActionResult Direcciones()
        {
            var q = db.DireccionEnvios.Select(u => u).ToList();
            return Ok(q);
        }
        //--------------------------------------------LineaPedidos-------------------------------------------------
        [HttpGet]
        [Route("Admin/LineaPedidos/{idPlato:int}")]
        public IActionResult LineaPedidos(int idPlato)
        {
            var linea = db.LineaPedidos.ToList();
            var query = from cust in linea where cust.id_Pedido == idPlato select cust;
            return Ok(query);
        }
        [HttpGet]
        [Route("Admin/LineaPed/{idPlato:int}")]
        public IActionResult LineaPed(int idPlato)
        {
            
            var pedido = db.Pedidos.Find(idPlato);
            var linea = db.LineaPedidos.ToList();
            var query = from cust in linea where cust.id_Pedido == idPlato select cust;

            List<DTOLPedidoAngular> list = new List<DTOLPedidoAngular>();
            if(pedido.Id_Direccion!=0)
                foreach (var q in query)
                {

                    var plato = db.Platos.Find(q.id_Plato);
                    var direccion = db.DireccionEnvios.Find(pedido.Id_Direccion);
                    DTOLPedidoAngular mi = new DTOLPedidoAngular()
                    {
                        id_LineaPedido = q.id_LineaPedido,
                        nombrePlato = plato.NombrePlato,
                        direccionEnvio = direccion.Nombre_Direccion,
                        municipio = direccion.Municipal,
                        provincia = direccion.Provincia,
                        cantidad = q.Cantidad,
                        precioUnitario = q.PrecioProductoUnitario,
                        precioTotal = q.PrecioTotal,
                        descripPlato = plato.DescripcionPlato,
                    };
                    list.Add(mi);
                }
            else
                foreach (var q in query)
                {

                    var plato = db.Platos.Find(q.id_Plato);
                   
                    DTOLPedidoAngular mi = new DTOLPedidoAngular()
                    {
                        id_LineaPedido = q.id_LineaPedido,
                        nombrePlato = plato.NombrePlato,  
                        cantidad = q.Cantidad,
                        precioUnitario = q.PrecioProductoUnitario,
                        precioTotal = q.PrecioTotal,
                        descripPlato = plato.DescripcionPlato,
                    };
                    list.Add(mi);
                }


            return Ok(list);
        }
        //--------------------------------------------Platos-------------------------------------------------------
        [HttpGet]
        [Route("Admin/Platos")]
        public IActionResult Platos()
        {
            //var q = (from u in db.Users select u).ToList();
            var q = db.Platos.Select(u => u).ToList();
            return Ok(q);
        }
        [HttpGet]
        [Route("Admin/Plato/createplato")]
        public IActionResult CreatePlato()
        {
            return View();
        }
        [HttpPost]
        [Route("Admin/Plato/createplato")]
        public IActionResult CreatePlato([FromBody] DTOPlato plato)
        {
            if (ModelState.IsValid)
            {
                //TO DO
                global::Restaurante.Plato miProducto = new global::Restaurante.Plato()
                {
                    NombrePlato = plato.NombrePlato,
                    DescripcionPlato = plato.DescripcionPlato,
                    PrecioBase = plato.PrecioBase,
                    TipoPlato= plato.TipoPlato,
                    ImagePath = plato.ImagePath,
                };

                db.Platos.Add(miProducto);
                db.SaveChanges();
                return Ok(200);
            }
            return View();
        }
        [HttpDelete]
        [Route("Admin/DeletePlato/{idPlato:int}")]
        public IActionResult DeletePlato(int idPlato)
        {
            global::Restaurante.Plato p = db.Platos.Find(idPlato);
            if (p != null)
            {
                db.Platos.Remove(p);
                db.SaveChanges();
            }
            return Ok(200);

        }
        //----------------------------------------------Reserva---------------------------------------------------------
        [HttpGet]
        [Route("Admin/Reserva")]
        public IActionResult Reserva()
        {
            //var q = (from u in db.Users select u).ToList();
            var q = db.Reservas.Select(u => u).ToList();
            return Ok(q);
        }
        [HttpDelete]
        [Route("Admin/DeleteReserva/{idPlato:int}")]
        public IActionResult DeleteReserva(int idPlato)
        {
            global::Restaurante.Reserva p = db.Reservas.Find(idPlato);
            if (p != null)
            {
                db.Reservas.Remove(p);
                db.SaveChanges();
            }
            return Ok(200);
        }
    }
}
