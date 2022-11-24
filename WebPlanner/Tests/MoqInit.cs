using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Entity;

namespace Tests
{
    public class MoqInit
    {
        public Account[] mockData = new Account[]
        {
            new Account()
            {
                Name = "Dmitry Korzum",
                Id = 1,
                Email = "poste4dima@gmail.com",
                Salt = "1668641742,491674",
                HashPassword = "3e717ada439e9117eaf4fcaba91c9579a63b7b94c8c2157f09d26690777b3ff9",
                AccountType = "User"
            },
            new Account()
            {
                Name = "Alex",
                Id = 2,
                Email = "poste3dima@gmail.com",
                Salt = "1668124418,173396",
                HashPassword = "7ea142fff58d9778e4de295498b2aaf4b874fa17c631c9b99c6e0170b85e96fd",
                AccountType = "User"
            }
        };

        public Mock<IAccountRepository> MockAccountRepository()
        {
            Mock<IAccountRepository> mock = new Mock<IAccountRepository>();
            
            mock.Setup(x => x.GetAccountByEmail("poste4dima@gmail.com").Result).
                Returns(mockData[0]);
            return mock;
        }

    }
}
