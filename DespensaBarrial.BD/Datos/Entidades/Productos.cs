using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;




namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Productos:EntityBase
    {

        [Required]

        [MaxLength(9, ErrorMessage = "La clave debe ser una combinacion alfanumerica")]
        public string ClaveProducto { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required]

        public string DescripcionProducto { get; set; }


        public DateTime? FechaVencimientoProducto { get; set; }

        //deberia crear una llave foranea o compuesta que relacione ,

        //la tabla esta con la de proveedores


        [Required]

        [Precision(14, 2)]
        public decimal PrecioProducto { get; set; }

        public int DepositoId { get; set; }
        
        //clave foranea que relaciona Deposito con Productos

        public HashSet<Categorias> categorias { get; set; }


    }
}
