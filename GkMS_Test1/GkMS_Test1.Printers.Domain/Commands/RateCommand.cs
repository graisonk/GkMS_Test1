using GkMS_Test1.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Commands
{
    public abstract class RateCommand : Command
    {
        public int RefId { get; set; }
        public int ValFrom { get; set; }
        public int ValTo { get; set; }
        public double Rate { get; set; }
    }
}
