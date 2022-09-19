using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Proveedores
    {
        //mapeo flexible--> Para que los nombres de los proveedores empiecen con mayuscula

        public int IdProveedores { get; set; }

        public string _Nombre { get; set; }

        public string Nombre 
        {

            get
            {
                return _Nombre;
            }

            set 
            {

                //Esto lo que hace es unir cada de unos los caracteres,
                //que compone el nombre del Proveedor
                _Nombre = string.
                    Join(' ', value.
                    Split(' ').
                    Select(x => x[0].
                    ToString().
                    ToUpper() + x.
                    Substring(1).
                    ToLower().
                    ToArray()));
            }
        }

        public string CorreoElectronico { get; set; }

        public int NumeroTelefono { get; set; }

        public int AdministadorId { get; set; }

        public HashSet<Productos> Productos { get; set; }

    }
}
