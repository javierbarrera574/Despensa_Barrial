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


        [HttpPut("{id:int}")]

        //Actualizar el registro creado anteriormente con post atraves del id

        public async Task<ActionResult> Put(ProveedoresCreacionDTO

            proveedoresCreacionDTO, int id)


        {
            var proveedores = await context.Proveedores.
                AsTracking().
                FirstOrDefaultAsync(a => a.IdProveedores == id);

            if (proveedores is null)
            {
                return NotFound();
            }

            proveedores = mapper.Map(proveedoresCreacionDTO, proveedores);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> Post()
        {

            var proveedor = new Proveedores()
            {
                Nombre = "",

                CorreoElectronico = "",

                NumeroTelefono = 0,

                #region

                //categorias = new HashSet<Categorias>()
                //{
                //    //new Categorias()
                //    //{

                //    //    TipoDeCategoria = TipoDeCategoria.BebidasAlcoholicas,

                //    //},
                //    new Categorias()
                //    {
                //        Producto = new Productos()
                //        {
                //            NombreProducto="",
                //            DescripcionProducto="",
                //            PrecioProducto=1,
                //            FechaVencimientoProducto=new DateTime(2020,10,14),
                //            Categoria=TipoDeCategoria.BebidasAlcoholicas


                //        },
                //        //TipoDeCategoria=TipoDeCategoria.Lacteos,


                //    },

                //    new Categorias()
                //    {
                //        Producto = new Productos()
                //        {
                //            NombreProducto="",
                //            DescripcionProducto="",
                //            PrecioProducto=1,
                //            FechaVencimientoProducto=new DateTime(2019,11,23),
                //            Categoria=TipoDeCategoria.Lacteos

                //        },

                //        //TipoDeCategoria = TipoDeCategoria.Lacteos,

                //    },

                //    new Categorias()
                //    {
                //        Producto = new Productos()
                //        {
                //            NombreProducto="",
                //            DescripcionProducto="",
                //            PrecioProducto=3,
                //            FechaVencimientoProducto= new DateTime(2012,2,22),
                //            Categoria=TipoDeCategoria.Azucares

                //        }
                //    }
                //}

                #endregion


                Productos = new Productos()
                {
                    
                }


            };
        }
    }
}
