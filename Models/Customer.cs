using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace rjp_test.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
