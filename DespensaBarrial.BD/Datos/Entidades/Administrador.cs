using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Administrador
    {

        public int IdAdministrador { get; set; }

        public string Nombre { get; set; }

        public HashSet<Proveedores> ProveedoresAdministrador { get; set; }

        //me lleva al registro con la propiedad de navegacion

        public Empleado UnEmpleado { get; set; }


    }
}
