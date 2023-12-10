using rjp_test.Models;
using rjp_test.IServices;
using rjp_test.Data;
using Microsoft.AspNetCore.Mvc;

namespace rjp_test.Services
{
    public class AccountService :IAccountService
    {

        private readonly ApiContext _context;

        public AccountService(ApiContext context)
        {
            _context = context;
        }
        public Account OpenAccount(int customerId, float balance)
        {
            try
            {
                var customerDb = _context.Customers.Find(customerId);

                if (customerDb == null)
                {
                    throw new ArgumentException($"Customer with ID {customerId} not found.");
                }

                Account newAccount = new Account
                {
                    CustomerId = customerId,
                    Balance = balance
                };

                // Save the new account
                _context.Accounts.Add(newAccount);
                _context.SaveChanges();

                return newAccount;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; 
            }
        }






        public Account getAccountByCustomerId(int customerId)
        {
            try
            {
                var customerDb = _context.Customers.Find(customerId);

                if (customerDb == null)
                {
                    throw new ArgumentException($"Customer with ID {customerId} not found.");
                }


                var accountDb = _context.Accounts.FirstOrDefault(acc => acc.CustomerId == customerId);



                return accountDb;
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
