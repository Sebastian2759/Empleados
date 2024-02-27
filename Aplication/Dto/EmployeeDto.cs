using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dto
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string? name { get; set; }
        public decimal salary { get; set; }
        public decimal salaryAnual { get; set; }
        public int age { get; set; }
        public string? urlImg { get; set; }
    }
}
