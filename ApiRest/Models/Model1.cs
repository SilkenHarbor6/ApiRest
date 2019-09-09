namespace ApiRest.Models
{
    using System.Data.Entity;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ClienteT> ClienteT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteT>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteT>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteT>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteT>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteT>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
