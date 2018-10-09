using System;
using System.Threading.Tasks;
using TestCards.Models;

namespace TestCards.Services
{
    public interface ICreditCardApplicationRepository
    {
        Task AddAsync(CreditCardApplication application);
    }
}
