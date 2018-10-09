using System;
using System.Threading.Tasks;
using TestCards.Models;

namespace TestCards.Services
{
    public interface ICreditCardData
    {
        Task AddAsync(CreditCardApplication application);
    }
}
