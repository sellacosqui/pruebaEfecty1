using PruebaEfeccty.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaEfeccty.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<PruebaEfeccty.Models.Formulario> Formulario { get; set; }
        public DbSet<PruebaEfeccty.Models.Tipo_Identificacion> Tipo_Identificacion { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Keys
            //Llaves primarias 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Formulario>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Tipo_Identificacion>()
                .HasKey(x => x.Id);
            
            #endregion
            
            #region llaves foraneas tabla Roles       
            modelBuilder.Entity<Formulario>()
           .HasOne(p => p.Tipo_Identificacionmodel)
           .WithMany()
           .HasForeignKey(b => b.Tipo_Identificacion);
            #endregion

        }

    }
}
