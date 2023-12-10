using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rjp_test.Models;
using rjp_test.Data;

namespace rjp_test.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ApiContext _context;

        public CustomerController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerDb = _context.Customers.Find(customer.Id);

                if (customerDb == null)
                {
                    return new JsonResult(NotFound());
                }
                customerDb = customer;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(customer));
        }

        [HttpGet]
        public JsonResult getCustomerById(int id)
        {
            var result = _context.Customers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }



        [HttpDelete]
        public JsonResult deleteCustomer(int id)
        {
            var result = _context.Customers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Customers.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }
        [HttpGet]
        public JsonResult getAllCustomers()
        {
            var result = _context.Customers.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
