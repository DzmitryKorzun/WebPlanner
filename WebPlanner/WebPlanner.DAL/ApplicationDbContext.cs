using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity;
using WebPlanner.Domain.Entity.GeneralModels;
using WebPlanner.Domain.Entity.ItemModels;

namespace WebPlanner.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #region DbSets
        #region GeneralDbSets
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemSubgrop> ItemSubgrops { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<HeadphonesConstruction> HeadphonesConstructions { get; set; }
        public DbSet<LightProjectorSource> LightProjects { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<WebPlanner.Domain.Entity.GeneralModels.OperatingSystem> OperatingSystems { get; set; }
        public DbSet<ProjectorMatrixType> ProjectorMatrixTypes { get; set; }
        public DbSet<ProjectorPurpose> ProjectorPurposes { get; set; }
        public DbSet<ScreenType> ScreenTypes { get; set; }
        public DbSet<StandartsWithTVresivers> StandssWithTVresivers { get; set; }
        public DbSet<TV_Type> TV_Types { get; set; }
        public DbSet<TVresiversStandart> TVresiversStandarts { get; set; }
        #endregion
        #region ItemDbSets
        public DbSet<DigitalTVreceiver> DigitalTVreceivers { get; set; }
        public DbSet<ElectronicBook> ElectronicBooks { get; set; }
        public DbSet<FitnessBracelet> FitnessBracelets { get; set; }
        public DbSet<Headphones> Headphones { get; set; }
        public DbSet<Projector> Projectors { get; set; }
        public DbSet<SmartPhone> SmartPhones { get; set; }
        public DbSet<Tablet> Tablets { get; set; }
        public DbSet<Television> Televisions { get; set; }
        #endregion
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tablet>().HasOne(p => p.Color).WithMany(t => t.Tablets).HasForeignKey(p =>p.Id_Color);
        }
    }
}
