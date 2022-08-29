using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DespensaBarrial.BD.Datos
{
    public abstract class EntityBase
    {

        [Key]

        [Required]

        public int Id { get; set; }

        // [DisplayFormat]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{ddd d / MMM / yyyy}")]
        public DateTime? FechaCreacion { get; set; }


    }
}
