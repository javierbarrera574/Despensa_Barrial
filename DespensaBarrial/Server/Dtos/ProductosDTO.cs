namespace DespensaBarrialAPI.Server.Dtos
{
    public class ProductosDTO
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public DateTime? FechaVencimientoProducto { get; set; }

    }
}
