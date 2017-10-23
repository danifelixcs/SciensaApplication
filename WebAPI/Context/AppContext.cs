using System.Data.Entity;
using WebAPI.Entities;

namespace WebAPI.Context
{
    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("data source=dfelixserver.database.windows.net;initial catalog=SciensaDB;persist security info=True;user id=dfelix;password=12132633aA@")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
