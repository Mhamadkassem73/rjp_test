using rjp_test.Models;
using rjp_test.IServices;
using rjp_test.Data;
using Microsoft.AspNetCore.Mvc;

namespace rjp_test.Services
{
    public class TransactionService :ITransactionService
    {

        private readonly ApiContext _context;

        public TransactionService(ApiContext context)
        {
            _context = context;
        }
        public Transaction ProcessTransaction(int accountId, float amount)
        {
            // Validate inputs
            if (accountId <= 0)
            {
                throw new ArgumentException("Invalid accountId or amount.");
            }

            // Check if the account exists
            var accountDb = _context.Accounts.Find(accountId);
            if (accountDb == null)
            {
                throw new ArgumentException($"Account with ID {accountId} not found.");
            }

            // Create a new transaction
            Transaction newTransaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount
            };

            try
            {
                _context.Transactions.Add(newTransaction);
                _context.SaveChanges();
                return newTransaction;
            }
            catch (Exception ex)
            {
                // Handle exceptions accordingly
                throw new Exception("Error processing transaction.", ex);
            }
        }


        public Transaction[] getTransactionsByAccountId(int accountId)
        {
            try
            {
                var accountDb = _context.Accounts.Find(accountId);

                if (accountDb == null)
                {
                    throw new ArgumentException($"Account with ID {accountDb} not found.");
                }


                Transaction[] transactionArray = _context.Transactions.Where(trans => trans.AccountId == accountId).ToArray();



                return transactionArray;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
