using rjp_test.Data;
using rjp_test.Models;

namespace rjp_test.Services
{
    public class SeedDataService
    {
        private readonly ApiContext _context;

        public SeedDataService(ApiContext context)
        {
            _context = context;
        }

        public void Seed()
        {


            //add default data
            if (!_context.Customers.Any())
            {
                _context.Customers.AddRange(
                    new Customer { Id = 1, Name = "Mohamad", Surname = "Kassem" },
                    new Customer { Id = 2, Name = "Miled", Surname = "Nasrallah" }
     
                );

                _context.SaveChanges();
            }
        }
    }

}
