using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class SaturationParameters : IParameters
    {
        [ParameterInfo(Name = "Коэффициент",
            MinValue = 0,
            MaxValue = 10,
            DefaultValue = 1,
            Increment = 0.05)]
        public double Coefficient { get; set; }
    }
    public class SaturationFilter : IFilter
    {
        private Photo modifiedPhoto;

        public Photo Process(Photo original, double[] parameters)
        {
            double coefficient = parameters[0];

            return modifiedPhoto;
        }

        public ParameterInfo[] GetParametersInfo()
        {
            var property = typeof(SaturationParameters).GetProperty("Coefficient");
            var attribute = property.GetCustomAttribute<ParameterInfo>();

            var parameterInfo = new ParameterInfo
            {
                Name = attribute.Name,
                MinValue = attribute.MinValue,
                MaxValue = attribute.MaxValue,
                DefaultValue = attribute.DefaultValue,
                Increment = attribute.Increment
            };

            return new ParameterInfo[] { parameterInfo };
        }
    }


}


