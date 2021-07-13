namespace web_home.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<classmate> classmate { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<classmate>()
                .Property(e => e.cname)
                .IsUnicode(false);

            modelBuilder.Entity<classmate>()
                .Property(e => e.cteacher)
                .IsUnicode(false);
        }
    }
}
