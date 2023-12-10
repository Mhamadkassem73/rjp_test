using rjp_test.Models;
using rjp_test.IServices;
using rjp_test.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
