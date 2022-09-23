using AutoMapper;
using DespensaBarrial.BD.Datos.Entidades;
using DespensaBarrialAPI.BD.Datos.Entidades;
using DespensaBarrialAPI.Server.Dtos;

namespace DespensaBarrialAPI.Server.Servicios
{
    public class AutoMapperPerfiles : Profile
    {
        public AutoMapperPerfiles()
        {

            CreateMap<ProductosCreacionDTO, Productos>()
              .ForMember(ent => ent.Categoria,
                  dto => dto.
                  MapFrom(campo => campo.Categorias.
                  Select(id => new Categorias()

                  { IdCategoria = id })));


            CreateMap<Productos, ProductosDTO>()
                .ForMember(dto => dto.Categorias, ent => ent.
                MapFrom(prop => prop.Categoria.
                Select(s => s.Producto)))
                .ForMember(dto => dto.Proveedores, ent =>
                    ent.
                    MapFrom(prop => prop.ProveedorProductos.
                    Select(pa => pa.Proveedores)));

            CreateMap<ProveedoresProductosCreacionDTO, ProveedorProducto>();

            CreateMap<ProveedoresDTO, Proveedores>();

            



        }
    }
}