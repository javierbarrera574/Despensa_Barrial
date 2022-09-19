using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Empleado
    {

        public int IdEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public ulong EdadEmpleado { get; set; }
 
        public DateTime? FechaNacimiento { get; set; }

        public string Domicilio { get; set; }

        public ulong NumeroTelefono { get; set; }

        public int AdministradorId { get; set; }
        
        //clave foreanea de la relacion UNO a UNO entre Administrador y Empleado
    }
}
