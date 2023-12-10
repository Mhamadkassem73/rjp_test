using Castle.Core.Resource;
using rjp_test.Models;

namespace rjp_test.ViewModels
{
        public class InformationViewModel
        {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Balance { get; set; }

        public Transaction[]? Transactions { get; set; }



    }


}
