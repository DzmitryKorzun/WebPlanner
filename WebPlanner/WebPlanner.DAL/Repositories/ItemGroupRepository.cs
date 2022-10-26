using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;

namespace WebPlanner.DAL.Repositories
{
    public class ItemGroupRepository: IItemGroupRepository
    {
        private readonly ApplicationDbContext context;

        public ItemGroupRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            return await context.ItemGroups.Select(x => x.Name).ToArrayAsync();
        }
    }
}
