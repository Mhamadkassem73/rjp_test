using Microsoft.EntityFrameworkCore;
using rjp_test.Models;
using System.Data.Common;

namespace rjp_test.Data
{
    public class ApiContext:DbContext
    {

        public  DbSet<Customer> Customers {  get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) {}

    }
}
