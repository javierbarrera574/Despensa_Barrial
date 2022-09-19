using DespensaBarrialAPI.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Categorias
    {

        public int IdCategorias { get; set; }

        public TipoDeCategoria TipoDeCategoria { get; set; }
      
        public int ProveedorId { get; set; }

        public Proveedores Proveedores { get; set; }

        public int ProductoId { get; set; }


        //TENGO DOS CLAVES FORANEAS PROVENIENTES DE LA RELACION UNO A MUCHOS DE PROVEEDORES

        //A LA ENTIDAD PRODUCTOS, CON LA CARDINALIDAD UNO A MUCHOS

        //CONVIRTIENDOSE EN UN TIPO DE RELACION MUCHOS A MUCHOS

        public HashSet<Productos> ProductosEnCategorias { get; set; }

        //public ICollection<Productos> ProductosCategorias { get; set; }//podemos realizar ordenamientos por lista

        //Capaz use ICollection para hacer ordenamiento 

        /*
         * QUIERE DECIR QUE EN UNA MISMA CATEGORIA PUEDE HABER MUCHOS PRODUCTOS
         */


    }
}
