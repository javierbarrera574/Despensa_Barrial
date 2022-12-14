using AutoMapper;
using AutoMapper.QueryableExtensions;
using DespensaBarrial.BD.Datos;
using DespensaBarrial.BD.Datos.Entidades;
using DespensaBarrialAPI.BD.Datos.Entidades;
using DespensaBarrialAPI.Server.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespensaBarrialAPI.Server.Controllers
{

    [ApiController]
    [Route("api/Proveedores")]

    public class ProveedoresControlador : ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;

        private readonly IMapper mapper;

        public ProveedoresControlador(DespensaBarrialAPIDbContext contexto, IMapper Mapper)
        {
            this.context = contexto;

            this.mapper = Mapper;

        }


        [HttpGet("MostrarProveedores")]
        public async Task<IEnumerable<ProveedoresDTO>> Get()
        {
            return await context.Proveedores
                .ProjectTo<ProveedoresDTO>(mapper.ConfigurationProvider).
                ToListAsync();
        }


        [HttpPost("AgregarProveedores")]
        public async Task<ActionResult> Post(ProveedoresCreacionDTO proveedoresCreacionDTO)
        {
            var proveedores = mapper.Map<Proveedores>(proveedoresCreacionDTO);
            context.Add(proveedores);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]//Actualizar el registro creado anteriormente con post atraves del id
        public async Task<ActionResult> Put(ProveedoresCreacionDTO proveedoresCreacionDTO,
            int id)
        {
            var proveedoresDB = await context.Proveedores.
                AsTracking().
                FirstOrDefaultAsync(a => a.IdProveedores == id);

            if (proveedoresDB is null)
            {
                return NotFound();
            }

            proveedoresDB = mapper.Map(proveedoresCreacionDTO, proveedoresDB);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("desconectado/{id:int}")]
        public async Task<ActionResult> PutDesconectado(ProveedoresCreacionDTO 
            
            proveedoresCreacionDTO,
            int id)

        {
            var proveedoresExiste = await context.Proveedores.AnyAsync(a => a.IdProveedores == id);

            if (!proveedoresExiste)
            {
                return NotFound();
            }

            var proveedores = mapper.Map<Proveedores>(proveedoresCreacionDTO);
            proveedores.IdProveedores = id;

            context.Update(proveedores);
            await context.SaveChangesAsync();
            return Ok();
        }







    }
}
