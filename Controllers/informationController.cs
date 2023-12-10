using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rjp_test.IServices;

namespace rjp_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class informationController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public informationController(ICustomerService customerService, IAccountService accountService, ITransactionService transactionService)
        {
            _customerService = customerService;
            _accountService = accountService;
            _transactionService = transactionService;
        }

        [HttpGet]
        public JsonResult getUserInfromration(int customerId)
        {
            try
            {
                var customerDb = _customerService.getCustomerById(customerId);
                if (customerDb == null)
                {
                    return new JsonResult(NotFound());
                }
                var account = _accountService.getAccountByCustomerId(customerId);

                if(account == null)
                {
                    return new JsonResult(NotFound());
                }

                var transactions = _transactionService.getTransactionsByAccountId(account.Id);


                var data = new
                {
                    Name = customerDb.Name,
                    Surname = customerDb.Surname,
                    Balance = account.Balance,
                    Transactions = transactions,
                };

                return new JsonResult(Ok(data));
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500, "An error occurred while opening the account"));
            }
        }

    }
}
