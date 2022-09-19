using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrial.BD.Datos.Entidades
{
    public class Deposito
    {

        public int UnidadMinima { get; set; }

        public List<Productos> ProductosEnDeposito { get; set; }

        //PARA DEFINIR LAS RELACION DE CARDINALIDAD UNO A MUCHOS

        public Empleado EmpleadoDeposito { get; set; }


    }
}
