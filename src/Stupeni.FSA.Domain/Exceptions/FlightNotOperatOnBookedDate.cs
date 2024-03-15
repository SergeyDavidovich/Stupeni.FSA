using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Stupeni.FSA.Exceptions
{
    public class FlightNotOperatOnBookedDate : BusinessException
    {
        public FlightNotOperatOnBookedDate(string message)
            :base(message)
        {
                
        }
    }
}
