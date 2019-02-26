using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib
{
    public struct Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime IssueDate { get; set; }
        public string ResponsibleUser { get; set; }
        public double Price { get; set; }
        public int Garantee { get; set; }
        public string Description { get; set; }
    }
}
