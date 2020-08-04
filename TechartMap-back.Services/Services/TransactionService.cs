using System.Collections.Generic;
using System.Threading.Tasks;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Services.Services
{
    public class TransactionService :ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _transactionRepository.GetTransactions();
        }

        public async Task<Transaction> GetCurrentTransaction(int id)
        {
            var foundTransaction = await _transactionRepository.GetCurrentTransaction(id);

            return foundTransaction;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            await _transactionRepository.AddTransaction(new Transaction
            {
               
                Price = transaction.Price,
                Row = transaction.Row,
                PlaceId = transaction.PlaceId,
                Place = transaction.Place,
                Session = transaction.Session,
                SessionId = transaction.SessionId,
                TransactionType = transaction.TransactionType,
                User = transaction.User,
                UserLogin = transaction.UserLogin
               
            });
        }
    }
}