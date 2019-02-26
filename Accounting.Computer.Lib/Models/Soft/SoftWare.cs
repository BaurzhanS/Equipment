using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib.Models.Soft
{
    public enum SoftwareTypes { free, share}
    public struct SoftWare
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime InstalDate { get; set; }
        public SoftwareTypes SoftwareTypes { get; set; }
        public Equipment Equipment { get; set; }
    }
}
