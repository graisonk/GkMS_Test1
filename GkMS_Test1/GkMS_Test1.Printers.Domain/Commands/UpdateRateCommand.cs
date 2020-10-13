using System;
using System.Collections.Generic;
using System.Text;

namespace GkMS_Test1.Printers.Domain.Commands
{
    public class UpdateRateCommand : RateCommand
    {
        public UpdateRateCommand(int refid, int vfrom, int vto, double rate )
        {
            RefId = refid;
            ValFrom = vfrom;
            ValTo = vto;
            Rate = rate;
        }
    }
}
