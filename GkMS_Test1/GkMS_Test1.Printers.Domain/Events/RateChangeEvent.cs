using GkMS_Test1.Domain.Core.Events;
using GkMS_Test1.Printers.Domain.Models;
using GkMS_Test1.Users.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Events
{
    public class RateChangeEvent : Event    
    {
        public int RefId { get; set; }
        public int ValFrom { get; set; }
        public int ValTo { get; set; }
        public double Rate { get; set; }
        public RateChangeEvent(int refid, int valFrom, int valTo, double rate)
        {
            RefId = refid;
            ValFrom = valFrom;
            ValTo = valTo;
            Rate = rate;
        }
    }
}
