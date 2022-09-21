
using DespensaBarrial.BD.Datos.Entidades;

namespace DespensaBarrialAPI.BD.Datos.Entidades
{
    public class Categorias
    {
        public TipoDeCategoria TipoDeCategoria { get; set; }

        public HashSet<Productos> Producto { get; set; }

        public Proveedores Proveedor { get; set; }

    }
}
