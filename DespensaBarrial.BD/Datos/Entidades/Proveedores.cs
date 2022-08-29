using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Proveedores:EntityBase
    {
        [Required]

        public string Nombre { get; set; }

        [Required]


        [MaxLength(50)]

        public string CorreoElectronico { get; set; }

        [Required]

        [MaxLength(8, ErrorMessage = "El numero de telefono debe ser de {1} ocho caracteres")]
        public int NumeroTelefono { get; set; }


        [Column(TypeName = "Date")]

        public DateTime? FechaNacimiento { get; set; }


        [Required]

        [StringLength(8, ErrorMessage = "El DNI no debe superar los {1} nueve caracteres")]

        //La llave {1} toma el dato de limite de la coleccion
        public int DNI { get; set; }

        public HashSet<Categorias> categorias { get; set; }

        public int AdministadorId { get; set; }
    }
}
