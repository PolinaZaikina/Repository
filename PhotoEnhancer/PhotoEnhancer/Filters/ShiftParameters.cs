using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ShiftParameters : IParameters
    {
        [ParameterInfo(Name = "Сдвиг (%)",
                       MinValue = 0,
                       MaxValue = 100,
                       DefaultValue = 0,
                       Increment = 5)]
        public int ShiftPercentage { get; set; }
    }
}
