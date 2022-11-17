﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity;

namespace WebPlanner.DAL.Interfaces
{
    public interface IAccountRepository:IBasicRepository<Account>
    {
        public Task<Account> GetAccountByEmail(string email);
        public Task<int> GetLastAccountId();
        public Task<int> UpdateProfileInformation(Account account);
        public Task<int> ChangePassword(Account account, string? newPass, string? newSalt);
    }
}
