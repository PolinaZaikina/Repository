using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class TransformParameters : IParameters
    {
        [ParameterInfo(Name = "Ширина", MinValue = 0, MaxValue = 1000, DefaultValue = 100, Increment = 1)]
        public int Width { get; set; }

        [ParameterInfo(Name = "Высота", MinValue = 0, MaxValue = 1000, DefaultValue = 100, Increment = 1)]
        public int Height { get; set; }
    }

}
