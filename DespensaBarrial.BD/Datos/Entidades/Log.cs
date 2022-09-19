using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespensaBarrialAPI.BD.Datos.Entidades
{
    public class Log
    {
        //para evitar la repitencia de un id en otra tabla de la BB.DD o en otra

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string Mensaje{ get; set; }

    }
}