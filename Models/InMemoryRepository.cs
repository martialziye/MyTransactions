using Microsoft.EntityFrameworkCore;

namespace MyTransactions.Models
{
    public class InMemoryRepository
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();
       
        

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        public Transaction GetTransactionById(int id)
        {
            return _transactions.FirstOrDefault(t => t.Id == id);
        }

        public long AddTransaction(Transaction transaction)
        {
            transaction.Id = _transactions.Any() ? _transactions.Max(t => t.Id) + 1 : 1;
            _transactions.Add(transaction);
            return transaction.Id;
        }

        public long UpdateTransaction(int id, Transaction transaction)
        {
            var existingTransaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (existingTransaction != null)
            {
                existingTransaction.Description = transaction.Description;
                existingTransaction.Montant = transaction.Montant;
                existingTransaction.Date = transaction.Date;
                existingTransaction.Type = transaction.Type;
                return existingTransaction.Id;
            }
            return -1;
        }

        public long DeleteTransaction(int id)
        {
            var transactionToDelete = _transactions.FirstOrDefault(t => t.Id == id);
            if (transactionToDelete != null)
            {
                _transactions.Remove(transactionToDelete);
                return transactionToDelete.Id;
            }
            return -1;
        }
    }
}
