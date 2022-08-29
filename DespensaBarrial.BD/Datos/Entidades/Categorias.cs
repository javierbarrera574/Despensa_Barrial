using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DespensaBarrial.BD.Datos.Entidades
{ 
    public class Categorias:EntityBase
    {

        [Required(ErrorMessage = "El Numero de categoria es indispensable")]

        [MaxLength(6, ErrorMessage = "El numero de telefono debe ser de {1} ocho caracteres")]

        //[MaxLength(6)]
        public string NumeroDeCategoria { get; set; }

        [Required(ErrorMessageResourceName ="El campo Id del proveedor es necesario")]

        public int ProveedorId { get; set; }

        public Proveedores Proveedores { get; set; }

        [Required(ErrorMessageResourceName = "El campo Id del producto es necesario")]

        public int ProductoId { get; set; }

        public Productos Productos { get; set; }

        //TENGO DOS CLAVES FORANEAS PROVENIENTES DE LA RELACION UNO A MUCHOS DE PROVEEDORES

        //A LA ENTIDAD PRODUCTOS, CON LA CARDINALIDAD UNO A MUCHOS

        //CONVIRTIENDOSE EN UN TIPO DE RELACION MUCHOS A MUCHOS

    }
}
