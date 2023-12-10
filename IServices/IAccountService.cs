using rjp_test.Models;

namespace rjp_test.IServices
{
    public interface IAccountService
    {
        Account OpenAccount(int customerId,float balance);
        Account getAccountByCustomerId(int customerId);
    }
}
