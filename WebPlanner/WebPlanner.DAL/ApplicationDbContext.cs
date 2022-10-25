using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity;

namespace WebPlanner.DAL
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        #region DbSets

        public DbSet<ItemGroup> itemGroups { get; set; }
        public DbSet<ItemSubgrop> itemSubgrops { get; set; }


        #endregion

    }
}
