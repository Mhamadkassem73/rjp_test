using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rjp_test.IServices;
using rjp_test.Services;


namespace rjp_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public AccountController(ICustomerService customerService,IAccountService accountService, ITransactionService transactionService)
        {
            _customerService = customerService;
            _accountService = accountService;
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult openAccount(int customerId, float initialCredit)
        {
            try
            {
                    var customerDb = _customerService.getCustomerById(customerId);
                if (customerDb == null)
                {
                    return BadRequest("Invalid input parameters");
                }
                var account = _accountService.OpenAccount(customerId, initialCredit);
                if (account == null)
                {
                    return StatusCode(500, "An error occurred while opening the account");
                }
                if (initialCredit != 0 && account != null)
                {
                    _transactionService.ProcessTransaction(account.Id, initialCredit);
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
