using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Entity.GeneralModels;

namespace WebPlanner.DAL.Repositories
{
    public class ItemGroupRepository: IItemGroupRepository
    {
        private readonly ApplicationDbContext context;

        public ItemGroupRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(ItemGroup entity)
        {
            context.ItemGroups.Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var item = context.ItemGroups.FirstOrDefault(x => x.Id == Id);
            if (item != null)
            {
                context.ItemGroups.Remove(item);
            }
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            return await context.ItemGroups.Select(x => x.Name).ToArrayAsync();
        }


        public Task<int> Update(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
