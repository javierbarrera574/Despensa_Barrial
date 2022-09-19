using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DespensaBarrial.BD.Datos.Entidades;

namespace DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones
{
    internal class CategoriasConfiguracion : IEntityTypeConfiguration<Categorias>
    {
        public void Configure(EntityTypeBuilder<Categorias> builder)
        {


     
            builder.
                Property(prop => prop.TipoDeCategoria).
                HasDefaultValue(TipoDeCategoria.BebidasAlcoholicas);
         
            builder.
                Property(prop => prop.TipoDeCategoria).
                HasDefaultValue(TipoDeCategoria.Lacteos);

            
            builder.
                Property(prop => prop.TipoDeCategoria).
                HasDefaultValue(TipoDeCategoria.Azucares);

            builder.
                Property(prop => prop.TipoDeCategoria).
                HasDefaultValue(TipoDeCategoria.Harinas);

           
            builder.
                Property(prop => prop.TipoDeCategoria).
                HasDefaultValue(TipoDeCategoria.Fiambres);

            builder.
                Property(prop => prop.TipoDeCategoria).
                HasDefaultValue(TipoDeCategoria.Golosinas);

        }
    }
}
