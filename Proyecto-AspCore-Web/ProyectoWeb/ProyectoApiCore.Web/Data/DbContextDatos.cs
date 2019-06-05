using ProyectoApiCore.Web;
using Microsoft.EntityFrameworkCore;

namespace ProyectoApiCore.Web.Contexto
{
    public class DbContextDatos : DbContext
    {

        public virtual DbSet<Actividades> Actividad { get; set; }
        public virtual DbSet<ActividadesEquipo> ActividadEquipo { get; set; }
        public virtual DbSet<EquiposProyecto> EquipoProyecto { get; set; }
        public virtual DbSet<Equipos> Equipo { get; set; }
        public virtual DbSet<Integrantes> Integrante { get; set; }
        public virtual DbSet<Proyectos> Proyecto { get; set; }
        public virtual DbSet<TiposDocumento> TipoDocumento { get; set; }
        public virtual DbSet<IntegrantesEquipo> IntegranteEquipo { get; set; }

        public virtual DbSet<EstadoActividad> EstadoActividades { get; set; }


        public DbContextDatos(DbContextOptions<DbContextDatos> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ActividadesMap());
            modelBuilder.ApplyConfiguration(new ActividadesEquipoMap());
            modelBuilder.ApplyConfiguration(new EquiposProyectoMap());
            modelBuilder.ApplyConfiguration(new EquiposMap());
            modelBuilder.ApplyConfiguration(new IntegrantesMap());
            modelBuilder.ApplyConfiguration(new ProyectosMap());
            modelBuilder.ApplyConfiguration(new TiposDocumentoMap());
            modelBuilder.ApplyConfiguration(new IntegrantesEquipoMap());

            modelBuilder.ApplyConfiguration(new EstadoActividadMap());

        }

    }
}
