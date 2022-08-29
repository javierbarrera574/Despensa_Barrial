using DespensaBarrial.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrial.BD.Datos
{
    public class DespensaBarrialDbContext : DbContext
    {
        public DespensaBarrialDbContext(DbContextOptions options) : base(options) { }
       
        


        public DbSet<Categorias> Categorias { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Empleado> empleado { get; set; }

        public DbSet<Deposito> stockDeposito { get; set; }

        public DbSet<Administrador> administrador { get; set; }

    }
}
