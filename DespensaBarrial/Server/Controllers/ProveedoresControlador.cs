using AutoMapper;
using AutoMapper.QueryableExtensions;
using DespensaBarrial.BD.Datos;
using DespensaBarrial.BD.Datos.Entidades;
using DespensaBarrialAPI.Server.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialAPI.Server.Controllers
{


    [ApiController]

    [Route("api/Proveedores")]
    public class ProveedoresControlador:ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;

        private readonly IMapper mapper1;

        public ProveedoresControlador(DespensaBarrialAPIDbContext contexto, IMapper mapper)
        {
            this.context = contexto;

            this.mapper1 = mapper;
        }



        [HttpGet("MostrarProveedores")]



        public async Task<IEnumerable<Proveedores>> Get()
        {

            return await context.Proveedores.ToListAsync();

        }
        public async Task<IEnumerable<ProveedoresDTO>> GetAutoMapper()
        {
            return await context.Productos.ProjectTo<ProveedoresDTO>(mapper1.ConfigurationProvider).ToListAsync();
        }



        [HttpPost]

        public async Task<ActionResult> PostCreacion(ProveedoresCreacionDTO proveedoresCreacionDTO)
        {

            var proveedor = mapper1.Map<Proveedores>(proveedoresCreacionDTO);

            context.Add(proveedor);

            await context.SaveChangesAsync();

            return Ok();

        }

        
        [HttpPut]//endpoint de actualizacion

        public async Task<ActionResult> Put(ProveedoresCreacionDTO 
            proveedoresCreacionDTO, int id)
        {

            var proveedoresDB = await context.Proveedores.AsTracking().FirstOrDefaultAsync(prop=>prop.IdProveedores==id);

            if (proveedoresDB is null)
            {
                return NotFound();
            }

            proveedoresDB = mapper1.Map(proveedoresCreacionDTO, proveedoresDB);

            //AutoMapper mantiene la misma instancia de proveedorDB en memoria

            await context.SaveChangesAsync();

            return Ok();

        }


    
    }
}
