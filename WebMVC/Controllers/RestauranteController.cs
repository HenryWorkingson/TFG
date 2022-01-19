using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Restaurante;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.DTOS;

namespace WebMVC.Controllers
{
    public class RestauranteController : Controller
    {
        protected AplicationDbContext db;
        public RestauranteController(AplicationDbContext _db)
        {
            db = _db;
        }

        //------------------------------------------------Plato-----------------------------------------------------------------
        [HttpGet]
        [Route("Restaurante/Plato")]
        public IActionResult getPlato()
        {
            //var q = (from u in db.Users select u).ToList();
            var q = db.Platos.Select(u => u).ToList();
            return Ok(q);

            
        }

        //------------------------------------------------Pedido-----------------------------------------------------------------
        [HttpGet]
        [Route("Restaurante/GetLineaPedido/")]
        public async Task<IActionResult> Pedido()
        {
            var num = db.Pedidos.ToArray().Last();
            var linea =db.LineaPedidos.ToList();
            var query =from cust in linea where cust.id_Pedido == num.id_Pedido select cust;
 


            List<DTOLPedidoAngular> list = new List<DTOLPedidoAngular>();

            foreach (var q in query)
            {
                
                var plato=db.Platos.Find(q.id_Plato);
                var direccion = db.DireccionEnvios.Find(num.Id_Direccion);
                DTOLPedidoAngular mi = new DTOLPedidoAngular()
                {
                    id_LineaPedido = q.id_LineaPedido,
                    nombrePlato=plato.NombrePlato,
                    direccionEnvio=direccion.Nombre_Direccion,
                    municipio=direccion.Municipal,
                    provincia=direccion.Provincia,
                    cantidad=q.Cantidad,
                    precioUnitario=q.PrecioProductoUnitario,
                    precioTotal=q.PrecioTotal,
                    descripPlato=plato.DescripcionPlato,
                };
                list.Add(mi);
            }
            await db.SaveChangesAsync();

            return Ok(list);
        }

        [HttpGet]
        [Route("Restaurante/CrearPedido")]
        public IActionResult CrearPedido()
        {
            //var q = db.Pedidos.Select(u => u).ToList();
            return View();
        }
        [HttpPost]
        [Route("Restaurante/CrearPedido")]
        public async Task<IActionResult> CrearPedido([FromBody] DTOPedido pedido)
        {
            double precioTotal = 0;
            var l = db.Carros;
            global::Restaurante.Pedido miPedido = new global::Restaurante.Pedido()
            {
                Id_Direccion = 0,
                Precio_Total = precioTotal,
                Tarjeta = 0,
                Descripcion_Pedido = pedido.Descripcion_Pedido
            };
            db.Pedidos.Add(miPedido);
            db.SaveChanges();
            foreach (var q in l)
            {
                global::Restaurante.LineaPedido mi = new global::Restaurante.LineaPedido()
                {
                    Cantidad = q.Cantidad,
                    id_Pedido = miPedido.id_Pedido,
                    id_Plato = q.idPlato,
                    PrecioProductoUnitario = q.PrecioProductoUnitario,
                    PrecioTotal = q.PrecioProductoUnitario * q.Cantidad,

                };
                precioTotal += mi.PrecioTotal;
                db.LineaPedidos.Add(mi);
                db.Carros.Remove(q);
            }
            miPedido.Precio_Total = precioTotal;
            db.SaveChanges();
            //-------------------------------Tarjeta--------------------------------------

            global::Restaurante.Tarjeta miTarjetas = new global::Restaurante.Tarjeta()
            {
                FechaCadu_Tarjeta = pedido.FechaCadu_Tarjeta,
                Nom_Propietario = pedido.Nom_Propietario,
                Numero_Tarjeta = pedido.Numero_Tarjeta

            };
            db.Tarjetas.Add(miTarjetas);
            db.SaveChanges();
            //-------------------------------Tarjeta--------------------------------------
            //-------------------------------Direccion------------------------------------
            global::Restaurante.Direccion_Envio miDir = new global::Restaurante.Direccion_Envio()
            {
                DNI_Cliente_Rceiv = pedido.DNI_Cliente_Rceiv,
                Nombre_Cliente_Rec = pedido.Nombre_Cliente_Rec,
                Municipal = pedido.Municipal,
                Provincia = pedido.Provincia,
                Nombre_Direccion = pedido.Nombre_Direccion,
                Telefono_Cliente = pedido.Telefono_Cliente,
            };
            db.DireccionEnvios.Add(miDir);
            db.SaveChanges();
            //-------------------------------Direccion------------------------------------
            miPedido.Id_Direccion = miDir.id_DireccionEnvio;
            miPedido.Tarjeta = miTarjetas.id_Tarjeta;
            miPedido.Precio_Total = precioTotal;
            db.Pedidos.Update(miPedido);
            await db.SaveChangesAsync();

            return Ok(miPedido);
        }

        //----------------------------------------------------Carro---------------------------------------------------------
        [HttpGet]
        [Route("Restaurante/Carro")]
        public IActionResult Carro()
        {
            var q = db.Carros.Select(u => u).ToList();
            return Ok(q);
        }
        [HttpPut]
        [Route("Restaurante/AddCarro/{idProducto:int}")]
        public IActionResult AddCarro(int IdProducto)
        {
            if (ModelState.IsValid)
            {
                var p = db.Platos.Find(IdProducto);
                global::Restaurante.Carro miCarro = new Carro()
                {
                    Cantidad = 1,
                    idPlato = IdProducto,
                    NombreProducto = p.NombrePlato,
                    PrecioProductoUnitario = p.PrecioBase,
                };
                miCarro.PrecioTotal = miCarro.Cantidad * miCarro.PrecioProductoUnitario;
                db.Carros.Add(miCarro);
                db.SaveChanges();

            }
            return RedirectToAction("Plato");
        }
        [HttpPut]
        [Route("Restaurante/AumentarCarro/{id:int}")]
        public IActionResult AumentarCarro(int id)
        {
            if (ModelState.IsValid)
            {
                var p = db.Carros.Find(id);
                p.Cantidad = p.Cantidad + 1;
                p.PrecioTotal = p.Cantidad * p.PrecioProductoUnitario;
                db.SaveChanges();
                
            }
            return RedirectToAction("Carro");
        }
        [HttpPut]
        [Route("Restaurante/DecrementarCarro/{id:int}")]
        public IActionResult DecrementarCarro(int id)
        {
            if (ModelState.IsValid)
            {
                var p = db.Carros.Find(id);
                p.Cantidad = p.Cantidad - 1;
                if (p.Cantidad == 0)
                {
                    db.Carros.Remove(p);
                    db.SaveChanges();
                    return RedirectToAction("Carro");
                }
                p.PrecioTotal = p.Cantidad * p.PrecioProductoUnitario;
                db.SaveChanges();
                
            }
            return RedirectToAction("Carro");
        }
        [HttpDelete]
        [Route("Restaurante/DeleteCarro/{id:int}")]
        public IActionResult DeleteCarro(int id)
        {
            Carro p = db.Carros.Find(id);
            if (p != null)
            {
                db.Carros.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Carro");
        }

        //----------------------------------------------------Carro---------------------------------------------------------







        //----------------------------------------------------Tarjeta-------------------------------------------------------------
        [HttpGet]
        [Route("Restaurante/{idPedido:int}/CrearTarjetas")]
        public IActionResult CrearTarjetas(int idPedido)
        {
            return View();
        }
        [HttpPost]
        [Route("Restaurante/CrearTarjetas")]
        public IActionResult CrearTarjetas([FromBody]  DTOTarjeta Tarjeta)
        {
            if (ModelState.IsValid)
            {   //TO DO
                global::Restaurante.Tarjeta miTarjetas = new global::Restaurante.Tarjeta()
                {
                    FechaCadu_Tarjeta = Tarjeta.FechaCadu_Tarjeta,
                    Nom_Propietario = Tarjeta.Nom_Propietario,
                    Numero_Tarjeta = Tarjeta.Numero_Tarjeta
                    
                };
                db.Tarjetas.Add(miTarjetas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //-------------------------------------------------------Direccion--------------------------------------------------------------
        [HttpGet]
        [Route("Restaurante/Direcciones")]
        public IActionResult Direcciones()
        {
            var q=db.DireccionEnvios.ToList();
            return View(q);
        }

        [HttpGet]
        [Route("Restaurante/CrearDirecciones")]
        public IActionResult CrearDirecciones()
        {
            return View();
        }
        [HttpPost]
        [Route("Restaurante/CrearDirecciones")]
        public IActionResult CrearDirecciones([FromBody]  DTODireccion_Envio dir )
        {
            if (ModelState.IsValid)
            {   //TO DO
                global::Restaurante.Direccion_Envio miDir = new global::Restaurante.Direccion_Envio()
                {
                    DNI_Cliente_Rceiv = dir.DNI_Cliente_Rceiv,
                    Nombre_Cliente_Rec =dir.Nombre_Cliente_Rec,
                    Municipal = dir.Municipal,
                    Provincia = dir.Provincia,
                    Nombre_Direccion = dir.Nombre_Direccion,
                    Telefono_Cliente=dir.Telefono_Cliente
                };
                db.DireccionEnvios.Add(miDir);
                db.SaveChanges();
                return Ok();
            }
            return View();
        }

        //-------------------------------------------------------Direccion--------------------------------------------------------------
        // GET: HomeController1

        public ActionResult Index()
        {
            return View();
        }


        // GET: HomeController1/Details/5
        [HttpGet]
        [Route("Restaurante/Privacy")]
        public ActionResult Privacy(int id)
        {
            return View();
        }

        //-------------------------------- Reserva-------------------------------------
        [HttpGet]
        [Route("Restaurante/Reserva")]
        public IActionResult CrearReserva(int idPedido)
        {
            return View();
        }
        [HttpPost]
        [Route("Restaurante/CrearReserva")]
        async public Task<IActionResult> CrearReserva([FromBody] DTOReserva Reserva)
        {
            if (ModelState.IsValid)
            {   //TO DO
                global::Restaurante.Reserva miReserva = new global::Restaurante.Reserva()
                {
                    reservaNombre= Reserva.reservaNombre,
                    reservaTelefono=Reserva.reservaTelefono,
                    numeroPersonas = Reserva.numeroPersonas,
                    reservaDate =Reserva.reservaDate,
                    reservaTime=Reserva.reservaTime,
                    

                };
                db.Reservas.Add(miReserva);
                db.SaveChanges();
                await db.SaveChangesAsync();
                return Ok(200);
            }
            return View();
        }
    }
}
