using DespensaBarrial.BD.Datos;
using DespensaBarrial.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialAPI.Server.Controllers
{

    [ApiController]

    [Route("api/Categorias")]
    public class CategoriasControlador : ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;

        public CategoriasControlador(DespensaBarrialAPIDbContext contexto)
        {
            this.context = contexto;
        }

        //endpoint de recepcion de datos-->muestro las Categorias cargadas 

        [HttpGet]

        public async Task<IEnumerable<Categorias>> get()
        {
            return await context.Categorias.AsNoTracking().ToListAsync();

            //con AsNoTracking()-->Hago carga mas rapida de queries y de datos en paralelo

        }

        [HttpGet("Primero")]

        //Ordenando por numero de categoria
        public async Task<IEnumerable<Categorias>> Primer()
        {
            var categorias = await context.Categorias.OrderBy(prop=>prop.NumeroDeCategoria).ToListAsync();


            return categorias;

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Categorias>> BuscarGet(int id)
        {

            var categoria = await context.Categorias.FirstOrDefaultAsync(prop=>prop.IdCategorias==id);

            if (categoria is null)
            {
                return NotFound();
            }


            return categoria;
        }

        #region
        //[HttpGet("Paginacion")]

        ////Para cortar la cantidad necesaria solicitada del total

        //public async Task<ActionResult<IEnumerable<Categorias>>> Paginar()
        //{

        //    var categorias = await context.Categorias.Take(2).ToListAsync();

        //    return categorias;

        //}
        #endregion




    }
}
