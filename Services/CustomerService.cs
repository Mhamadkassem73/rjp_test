using rjp_test.Models;
using rjp_test.IServices;
using rjp_test.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace rjp_test.Services
{
    public class CustomerService :ICustomerService
    {

        private readonly ApiContext _context;

        public CustomerService(ApiContext context)
        {
            _context = context;
        }

        public Customer getCustomerById(int id)
        {
            var result = _context.Customers.Find(id);

            if (result == null)
            {
                throw new ArgumentException($"Customer with ID {id} not found.");
            }

            return result;
        }

        public async Task<Customer[]> GetAllCustomersAsync()
        {
            try
            {
                Customer[] result = await _context.Customers.ToArrayAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred while fetching customers 123: {ex.Message}");
                throw; // Rethrow the exception to propagate it further
            }
        }
    }
}
