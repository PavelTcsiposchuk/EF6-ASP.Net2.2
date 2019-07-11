using FamilyNet.Data.Entity;
using FamilyNet.Data.UnitOfWork;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace FamilyNet.Data.Interfaces
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(string conectionString)
            : base(conectionString) { }

        public DbSet<Orphan> Orphans { get; set; }
        public DbSet<CharityMaker> CharityMakers { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Orphanage> Orphanages { get; set; }
        public DbSet<Donation> Donations { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CharityMaker>()
        //        .HasRequired(chm => chm.Address);
                



        //    base.OnModelCreating(modelBuilder);
        //}

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ContextInitializer());

        }
    }

    public class ApplicationDbFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext("Server=(localdb)\\MSSQLLocalDB;Database=FamilyNet2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }

}
