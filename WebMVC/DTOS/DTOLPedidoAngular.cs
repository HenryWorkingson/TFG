namespace WebMVC.DTOS
{
    public class DTOLPedidoAngular
    {
        public int id_LineaPedido { get; set; }
        public string nombrePlato { get; set; }
        public string descripPlato { get; set; }
        public string direccionEnvio { get; set; }
        public string municipio { get; set; }
        public string provincia { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public double precioTotal { get; set; }
    }
}
