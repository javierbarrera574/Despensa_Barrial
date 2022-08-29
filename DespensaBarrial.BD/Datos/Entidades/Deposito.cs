using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Deposito:EntityBase
    {

        //Esta tabla tiene que estar relacionada con categorias y productos

        //Categorias es la tabla intermedia entre proveedores y productos

        [Required]

        [Range(1,10)]
        public int UnidadMinima { get; set; }

        public string CategoriaProducto { get; set; }

        //public Productos productosEnStock { get; set; }//para el tipo UNO A UNO

        ////ESTO QUIERE DECIR QUE EN EL DEPOSITO HAY UN PRODUCTO


        public List<Productos> ProductosEnDeposito { get; set; }

        //PARA DEFINIR LAS RELACION DE CARDINALIDAD UNO A MUCHOS

        public Empleado EmpleadoDeposito { get; set; }

        //Relacion de la tabla Empleado con Deposito para buscar productos en el Deposito



    }
}
