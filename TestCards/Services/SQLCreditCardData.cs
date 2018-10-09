using System;
using System.Threading.Tasks;
using TestCards.Data;
using TestCards.Models;

namespace TestCards.Services
{
    public class SQLCreditCardData : ICreditCardData
    {
        private readonly AppDbContext _dbContext;

        public SQLCreditCardData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(CreditCardApplication application)
        {
            _dbContext.CreditCardApplications.Add(application);

            return _dbContext.SaveChangesAsync();
        }
    }
}
