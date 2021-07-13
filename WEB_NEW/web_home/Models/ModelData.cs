namespace web_home.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelData : DbContext
    {
        public ModelData()
            : base("name=ModelData")
        {
        }

        public virtual DbSet<t_download_info> t_download_info { get; set; }
        public virtual DbSet<t_user> t_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_download_info>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_download_info>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<t_download_info>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.uaccount)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.token)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
