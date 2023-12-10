using Castle.Core.Resource;
using rjp_test.Models;

namespace rjp_test.ViewModels
{
        public class AccountViewModel
        {
            public int CustomerId { get; set; }
            public float InitialCredit { get; set; }

        
          public List<Customer>? Customers { get; set; } // List of Customer objects


    }

    
}
