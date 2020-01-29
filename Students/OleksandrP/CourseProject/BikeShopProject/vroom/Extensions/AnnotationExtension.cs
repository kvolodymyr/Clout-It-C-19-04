using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vroom.Extensions
{
    public class RangeTillCurrentYear : RangeAttribute
    {
        public RangeTillCurrentYear(int startYear) : base(startYear, DateTime.Now.Year)
        {

        }
    }
}
