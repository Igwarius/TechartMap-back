using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechartMap_back.DAL.Models;
using TechartMap_back.Services.Interfaces;

namespace TechartMap_back.Controllers
{
    [Route("transaction")]
    [ApiController]
    public class TransactionController:Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        [Route("transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var cities = await _transactionService.GetTransactions();
            return Ok(cities);
        }
        [HttpGet]
        [Route("transaction/{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transactions = await _transactionService.GetCurrentTransaction(id);
            return Ok(transactions);
        }
        [HttpPost]
        [Route("transaction")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            await _transactionService.AddTransaction(transaction);
            return Ok();
        }
    }
}