using AutoMapper;
using AutoMapper.QueryableExtensions;
using DespensaBarrial.BD.Datos;
using DespensaBarrial.BD.Datos.Entidades;
using DespensaBarrialAPI.BD.Datos.Entidades;
using DespensaBarrialAPI.Server.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialAPI.Server.Controllers
{

    [ApiController]

    [Route("api/Productos")]

    public class ProductosControlador : ControllerBase
    {
        private readonly DespensaBarrialAPIDbContext context;

        private readonly IMapper mapper;

        public ProductosControlador(DespensaBarrialAPIDbContext contexto, IMapper Mapper)
        {
            this.context = contexto;
            this.mapper = Mapper;
        }



        [HttpGet]


        public async Task<IEnumerable<ProductosDTO>> GetAutoMapper()
        {
            return await context.Productos.ProjectTo<ProductosDTO>(mapper.ConfigurationProvider).ToListAsync();
        }


        [HttpGet]


        //para que devuelva el query utilizando Select uso ActionResult
        public async Task<IEnumerable<ProductosDTO>> Get()
        {
            var productos = await context.Productos.Select(
                prop =>
                new ProductosDTO { Id = prop.IdProductos,
                    Nombre = prop.NombreProducto,
                    Descripcion = prop.DescripcionProducto,
                    Precio = prop.PrecioProducto }).ToListAsync();


            return productos;
        }

        //[HttpGet("OrdenarPorFecha")]-->Ver como hacerlo



        [HttpGet("{id:int}")]

        //Datos relacionados entre tablas:Relacion entre la tabla Productos y Categorias

        //Datos relacionados entre tablas: Relacion entre la tabla Productos y Proveedores

        public async Task<ActionResult<Productos>> Buscar(int id)
        {
            //en teoria me tendria que figurar en el Swagger los productos con sus respectivas categoria

            //y proveedores tambien con el nuevo include agregado


            var productos = await context.Productos.
                Include(prop => prop.CategoriasDeUnProducto).
                ThenInclude(prop => prop.TipoDeCategoria).
                Include(prop => prop.Proveedores).
                FirstOrDefaultAsync(prop => prop.IdProductos == id);

            return productos;

        }




        //https://www.udemy.com/course/introduccion-a-entity-framework-core-2-1-de-verdad/learn/lecture/29979422#reviews

        //ES EL VIDEO 47, DONDE HACE UN DTO DE UNA TABLA Y LE PASA COMO COLECCIONES LOS DEMAS DTOs

        //VER SI DESPUES ESTO HARIA FALTA



        //Usando ProjectTo()


        [HttpGet("UsandoProjecTo/{id:int}")]

        public async Task<ActionResult<ProductosDTO>> Buscar1(int id)
        {
            //en teoria me tendria que figurar en el Swagger los productos con sus respectivas categoria

            //y proveedores tambien con el nuevo include agregado


            var productos = await context.Productos.

                ProjectTo<ProductosDTO>(mapper.ConfigurationProvider).
                FirstOrDefaultAsync(prop => prop.Id == id);

            if (productos is null)
            {
                return NotFound();
            }

            return Ok(productos);

        }

        [HttpGet("CargaSelectiva/{id:int}")]

        public async Task<ActionResult> GetSelectivo(int id)
        {

            var productos = await context.Productos.Select(prop =>
            new
            {
                IdProductos = prop.IdProductos,

                NombreProducto = prop.NombreProducto,

                DescripcionProducto = prop.DescripcionProducto,

                FechaVencimientoProducto = prop.FechaVencimientoProducto,

                PrecioProducto = prop.PrecioProducto,

                Proveedores = prop.Proveedores.OrderByDescending(prop => prop.Nombre)//ordeno por el nombre del proveedor

            }

            ).FirstOrDefaultAsync(prop => prop.IdProductos == id);


            if (productos is null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        //Cargado explicito

        [HttpGet("CargadoExplicito/{id:int}")]


        public async Task<ActionResult<ProductosDTO>> GetExplicito(int id)
        {
            //carga posterior


            var producto = await context.Productos.
                AsTracking().
                FirstOrDefaultAsync(prop=>prop.IdProductos==id);


            //cargo si lo deseo tambien desde la coleccion de proveedores en productos

            await context.Entry(producto).Collection(p => p.Proveedores).LoadAsync();

            if (producto is null)
            {
                return NotFound();
            }

            var productoDTO = mapper.Map<ProductosDTO>(producto);

            return productoDTO;

        }


        //insertando registros


        [HttpPost("IngresarRegistros")]

        public async Task<ActionResult> Post(Productos productos)
        {

            context.Logs.Add(new Log { 

                Id=Guid.NewGuid(),

                Mensaje = "Ejecutando el metodo ProductosController.Get"});

            await context.SaveChangesAsync();

            var Estado = context.Entry(productos).State;//sin agregar

            //cambio el estado de productos a "agregado"

            context.Add(productos);

            var Estado1 = context.Entry(productos).State;//agregado

            //no es que lo esta agregando sino que esta proximo a agregar para cuando confirme la accion

            await context.SaveChangesAsync();//se confirma que se agrega

            var Estado2 = context.Entry(productos).State;//sin modificar

            return Ok();
        }


        [HttpPost("InsertarVariosRegistros")]

        public async Task<ActionResult> PostVarios(Productos[] productos)
        {

            context.Add(productos);

            await context.SaveChangesAsync();

            return Ok();
        
        }

        //Ver si es posible realizar el endpoint de productos y cargando los productos
        //segun las categorias y el tipo, desde el video 61 hasta el 63/64-->o ver el codigo del proyecto



        [HttpDelete("{id:int}")]//borrado normal

        public async Task<ActionResult> Delete(int id)
        {

            var producto = await context.Productos.FirstOrDefaultAsync(prop => prop.IdProductos == id);

            if (producto is null)
            {
                return NotFound();
            }

            context.Remove(producto);

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]

        public async Task<ActionResult> PostRepetir(Productos productos)
        {

            var ProductoExisteConEseNombre = await context.Productos.
                AnyAsync(prop => prop.NombreProducto == productos.NombreProducto);

            if (ProductoExisteConEseNombre)
            {
                return BadRequest
                    ($"Ya existe Producto con ese nombre: {productos.NombreProducto}");
            }
            return Ok();
        }
    }
}
