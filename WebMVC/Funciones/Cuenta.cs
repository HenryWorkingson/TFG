using System;
namespace WebMVC
{
    public class Cuenta
    {
        protected AplicationDbContext _context;
        public Cuenta(AplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCuenta(DTOCuenta cuenta)
        {
            global::Restaurante.Cuenta miCuenta = new global::Restaurante.Cuenta()
            {
                Nombre_Cuenta = cuenta.Nombre_Cuenta,
                Apellido_Cuenta = cuenta.Apellido_Cuenta,
                Password_Cuenta = cuenta.Password_Cuenta,
                Correo_Cuenta = cuenta.Correo_Cuenta,

            };

            _context.Cuentas.Add(miCuenta);
            //Guarda en BBDD
            _context.SaveChanges();
            return true;
        }
        public void listarCuentasConsola()
        {
            var list = _context.Cuentas;
            foreach (var ani in list)
            {
                Console.Write(ani.id_Cuenta + " ");
                Console.Write(ani.Nombre_Cuenta + " ");
                Console.Write(ani.Apellido_Cuenta + " ");
                Console.Write(ani.Correo_Cuenta + " ");
                Console.Write(ani.Password_Cuenta + " ");
            }
        }
        public void listarIdCuenta(int id)
        {
            var ani = _context.Cuentas.Find(id);
            //var q = (from u in db.cuentas select u).ToList();
            if (ani == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                Console.Write(ani.id_Cuenta + " ");
                Console.Write(ani.Nombre_Cuenta + " ");
                Console.Write(ani.Apellido_Cuenta + " ");
                Console.Write(ani.Correo_Cuenta + " ");
                Console.Write(ani.Password_Cuenta + " ");
            }
        }
        public void upDateCuenta(int id, DTOCuenta cuenta)
        {
            var q = _context.Cuentas.Find(id);
            if (q == null) { Console.WriteLine("No encontrado el id esperado"); }
            else
            {
                q.Nombre_Cuenta = cuenta.Nombre_Cuenta;
                q.Apellido_Cuenta = cuenta.Apellido_Cuenta;
                q.Correo_Cuenta = cuenta.Correo_Cuenta;
                q.Password_Cuenta = cuenta.Password_Cuenta;
            }
            _context.SaveChanges();
        }

    }
}
