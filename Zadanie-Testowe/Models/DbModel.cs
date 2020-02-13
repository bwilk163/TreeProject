namespace Zadanie_Testowe.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=Model1")
        {
        }

        public virtual DbSet<TreeElement> TreeElements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeElement>()
                .HasKey(t => t.ParentId);
        }
    }
}
