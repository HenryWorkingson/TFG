using System;
using System.Collections.Generic;

namespace WebMVC.Funciones
{
    public class Carro
    {
        private List<global::Restaurante.Plato> _articulos;

        public List<global::Restaurante.Plato> Articulos { get => _articulos; set => _articulos = value; }

        public Carro()
        {

            Articulos = new List<global::Restaurante.Plato>();

        }


        public bool AddItem(global::Restaurante.Plato articulo)
        {
            try
            {
                Articulos.Add(articulo);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveItem(global::Restaurante.Plato articulo)
        {
            try
            {
                Articulos.Remove(articulo);
                //Articulos.RemoveAll(_ => _.id_Producto == articulo.id_Producto);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RemoveAllItems()
        {

            try
            {
                Articulos.Clear();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<global::Restaurante.Plato> getAllItems()
        {
            foreach (var q in _articulos)
            {
                Console.Write(q.IdProducto + " ");
                Console.Write(q.DescripcionPlato + " ");
                Console.Write(q.PrecioBase + " ");
                Console.WriteLine(q.NombrePlato);
            }
            return _articulos;
        }
        public double PrecioTotal()
        {
            double result = 0;
            foreach (var q in _articulos)
            {
                result = result + q.PrecioBase;
            }
            return result;
        }
    }
}
