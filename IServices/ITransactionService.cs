
using rjp_test.Models;
namespace rjp_test.IServices;


public interface ITransactionService
{
    Transaction ProcessTransaction(int accountId, float amount);
    public Transaction[] getTransactionsByAccountId(int accountId);
}
