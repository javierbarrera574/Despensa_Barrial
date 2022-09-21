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
            if (cantidad<10)
            {

                var deposito = await context.Productos.FirstOrDefaultAsync(prop => prop.DepositoCantidad.UnidadMinima < cantidad);

                context.Add(deposito);

                await context.SaveChangesAsync();

            }
            return Ok();
        
        }


    }
}
