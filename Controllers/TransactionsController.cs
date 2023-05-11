using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTransactions.Models;

namespace MyTransactions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly InMemoryRepository _repository;

        public TransactionsController(InMemoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = _repository.GetAllTransactions();
            if (transactions == null || !transactions.Any())
            {
                return NotFound(new { message = "No Transaction found in the database" });
            }

            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactionById(int id)
        {
            var transaction = _repository.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound(new {message = $"Transaction with ID {id} does not exist in the database"});
            }

            return Ok(transaction);
        }

        [HttpPost]
        public ActionResult<int> AddTransaction(Transaction transaction)
        {
            var newTransactionId = _repository.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = newTransactionId }, newTransactionId);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            var updatedTransactionId = _repository.UpdateTransaction(id, transaction);
            if (updatedTransactionId == -1)
            {
                return NotFound(new { message = $"Transaction with ID {id} does not exist in the database" });
            }

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            var deletedTransactionId = _repository.DeleteTransaction(id);

            if (deletedTransactionId == -1)
            {
                return NotFound(new { message = $"Transaction with ID {id} does not exist in the database" });
            }

            return Ok(deletedTransactionId);
        }
    }
}
