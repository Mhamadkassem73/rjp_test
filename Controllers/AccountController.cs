using Castle.Core.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rjp_test.IServices;
using rjp_test.Models;
using rjp_test.Services;
using rjp_test.ViewModels;
using System.Data;


namespace rjp_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public AccountController(ICustomerService customerService, IAccountService accountService, ITransactionService transactionService)
        {
            _customerService = customerService;
            _accountService = accountService;
            _transactionService = transactionService;
        }


        [HttpGet]
        public async Task<IActionResult> OpenAccount()
        {
            try
            {
                Customer[] customers = await _customerService.GetAllCustomersAsync();

                var viewModel = new AccountViewModel
                {
                    Customers = customers.ToList(),
                    InitialCredit = 101
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching customers: {ex.Message}");
                throw;
            }
        }


        [HttpPost]
        public IActionResult OpenAccount([FromForm] AccountViewModel model)
        {
            
            Console.WriteLine(model.CustomerId);


            Console.WriteLine(model.InitialCredit);
           int CustomerId = model.CustomerId;
           float InitialCredit = model.InitialCredit;

            try
              {
                  var customerDb = _customerService.getCustomerById(CustomerId);
                  if (customerDb == null)
                  {
                      return BadRequest("Invalid input parameters");
                  }
                  var account = _accountService.OpenAccount(CustomerId, InitialCredit);
                  if (account == null)
                  {
                      return StatusCode(500, "An error occurred while opening the account");
                  }
                  if (InitialCredit != 0 && account != null)
                  {
                      _transactionService.ProcessTransaction(account.Id, InitialCredit);
                  }
                  return Ok("Account opened successfully");
              }
              catch (Exception ex)
              {
                  return StatusCode(500, "An error occurred while opening the account");
              }
          }
      }
        }
    


