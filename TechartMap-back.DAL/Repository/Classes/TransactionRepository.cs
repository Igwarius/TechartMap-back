using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly Context.Context _context;
        public TransactionRepository(Context.Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await Task.FromResult(_context.Transactions);
        }

        public async Task<Transaction> GetCurrentTransaction(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(a => a.Id == id);
            return transaction;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}