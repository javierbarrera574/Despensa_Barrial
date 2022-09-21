using AutoMapper;
using DespensaBarrial.BD.Datos.Entidades;
using DespensaBarrialAPI.Server.Dtos;

namespace DespensaBarrialAPI.Server.Servicios
{
    public class AutoMapperPerfiles : Profile
    {
        public AutoMapperPerfiles()
        {

            CreateMap<Productos, ProductosDTO>();


            CreateMap<Proveedores, ProveedoresDTO>();


            CreateMap<ProveedoresCreacionDTO, Proveedores>();


            CreateMap<ProveedorProductoCreacionDTO, ProveedorProducto>();

        }
    }
}