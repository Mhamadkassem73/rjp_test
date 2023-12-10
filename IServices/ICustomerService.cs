using rjp_test.Models;

namespace rjp_test.IServices
{
    public interface ICustomerService
    {
        Customer getCustomerById(int customerId);
    }
}
