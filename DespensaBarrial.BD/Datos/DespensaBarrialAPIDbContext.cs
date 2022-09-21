using DespensaBarrial.BD.Datos.Entidades;
using DespensaBarrialAPI.BD.Datos.Entidades;
using DespensaBarrialAPI.BD.Datos.Entidades.Configuraciones;
using EFCorePeliculas.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DespensaBarrial.BD.Datos
{
    public class DespensaBarrialAPIDbContext : DbContext
    {
        public DespensaBarrialAPIDbContext(DbContextOptions options) : base(options) { }


        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {

            modelConfigurationBuilder.Properties<DateTime>().HaveColumnType("Date");

        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //estas configuraciones las puedo hacer en al API Fluente

            //Escaneo el proyecto actual en busca de las configuraciones realizadas en el API Fluente

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            SeedingModuloConsulta.Seed(modelBuilder);

            modelBuilder.Entity<Log>().Property(p => p.Id).ValueGeneratedNever();

            #region
            //modelBuilder.ApplyConfiguration(new AdministradorConfiguracion());

            //modelBuilder.ApplyConfiguration(new CategoriasConfiguracion());


            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.NumeroDeCategoria).
            //    HasMaxLength(8).
            //    IsRequired();

            //modelBuilder.
            //    Entity<Proveedores>().
            //    Property(prop => prop.NumeroTelefono).
            //    HasMaxLength(9).IsRequired();

            //modelBuilder.
            //    Entity<Proveedores>().
            //    Property(prop => prop.CorreoElectronico).
            //    HasMaxLength(150).IsRequired();

            //modelBuilder.
            //    Entity<Proveedores>().
            //    Property(prop => prop.Nombre).
            //    IsRequired();

            //modelBuilder.
            //    Entity<Proveedores>().
            //    Property(prop => prop.DNI).
            //    HasMaxLength(8).
            //    IsRequired();



            ////modelBuilder.
            ////    Entity<Productos>().
            ////    Property(prop => prop.PrecioProducto).
            ////    HasPrecision(14, 2);

            //modelBuilder.
            //    Entity<Productos>().
            //    Property(prop => prop.PrecioProducto).
            //    HasPrecision(precision: 14, scale: 2);



            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.TipoDeCategoria).
            //    HasDefaultValue(TipoDeCategoria.BebidasAlcoholicas);


            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.TipoDeCategoria).
            //    HasDefaultValue(TipoDeCategoria.Lacteos);

            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.TipoDeCategoria).
            //    HasDefaultValue(TipoDeCategoria.Azucares);

            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.TipoDeCategoria).
            //    HasDefaultValue(TipoDeCategoria.Harinas);

            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.TipoDeCategoria).
            //    HasDefaultValue(TipoDeCategoria.Fiambres);

            //modelBuilder.
            //    Entity<Categorias>().
            //    Property(prop => prop.TipoDeCategoria).
            //    HasDefaultValue(TipoDeCategoria.Golosinas);

            #endregion
        }


        public DbSet<ProveedorProducto> ProveedorProducto{ get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Deposito> StockDeposito { get; set; }

        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Log> Logs { get; set; }

        public Categorias Categorias { get; set; }

    }
}
