using DespensaBarrial.BD.Datos;
using DespensaBarrial.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace DespensaBarrialAPI.Server.Controllers
{
    public class DepositoController:ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;

        private readonly IMapper Mapper;

        [HttpPost("AgregarProductos")]

        public async Task<ActionResult<Deposito>> Post(int cantidad)
        {

            var deposito = await context.Productos.FirstOrDefaultAsync(prop=>prop.depositoCantidad.UnidadMinima<cantidad);

            context.Add(deposito);

            await context.SaveChangesAsync();

            return Ok();
        
        }


    }
}
