using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;




namespace DespensaBarrial.BD.Datos.Entidades
{

    [Index(nameof(NombreProducto), IsUnique = true)]

    //Esto me garantiza que no haya dos productos con el mismo nombre

    public class Productos
    {

        public int IdProductos { get; set; }
       
        public string ClaveProducto { get; set; }
   
        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public DateTime? FechaVencimientoProducto { get; set; }

        public bool EstaBorrado { get; set; }

        //la tabla esta con la de proveedores

        public decimal PrecioProducto { get; set; }

        public int DepositoId { get; set; }
        
        //clave foranea que relaciona Deposito con Productos

        public Categorias CategoriasDeUnProducto { get; set; }

        public HashSet<Proveedores> Proveedores { get; set; }

        public Deposito depositoCantidad { get; set; }

    }
}
