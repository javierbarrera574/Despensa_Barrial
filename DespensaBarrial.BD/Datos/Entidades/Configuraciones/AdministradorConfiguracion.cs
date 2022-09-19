using DespensaBarrial.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones
{
    internal class AdministradorConfiguracion : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {

            builder.HasKey(prop => prop.IdAdministrador);

            builder.Property(prop=>prop.Nombre).IsRequired();

        }
    }
}
