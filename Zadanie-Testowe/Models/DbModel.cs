namespace Zadanie_Testowe.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;

    public partial class DbModel : DbContext
    {
        public DbSet<TreeElement> TreeElements { get; set; }
        public DbModel() : base("name=Model1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeElement>()
                .HasKey(t => t.Guid);
        }
    }
}
