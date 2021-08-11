using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetWebApi.Model
{
    public class EmployeeTask
    {
        public int ID { get; set; }

        public Employee AssignedEmployee { get; set; }
        public int AssignedEmployeeID { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
