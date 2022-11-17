using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Entity;

namespace WebPlanner.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext context;
        public AccountRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(Account entity)
        {
            context.Accounts.Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ChangePassword(Account account, string newPass, string newSalt)
        {
            var user = await context.Accounts.FirstOrDefaultAsync(x => x.Id == account.Id);
            if (user != null)
            {
                user.HashPassword = newPass;
                user.Salt = newSalt;
                return context.SaveChanges();
            }
            else return -1;

        }

        public Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            return await context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<int> GetLastAccountId()
        {
            return await context.Accounts.Select(x => x.Id).LastOrDefaultAsync();
        }

        public Task<int> Update(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateProfileInformation(Account updatedAccount)
        {
            var account = await context.Accounts.FirstOrDefaultAsync(x => x.Email == updatedAccount.Email);
            if (account != null)
            {
                account.Name = updatedAccount.Name;
                account.Bio = updatedAccount.Bio;
                account.URL = updatedAccount.URL;
                account.Location = updatedAccount.Location;
                return await context.SaveChangesAsync();
            }
            return -1;
        }
    }
}
