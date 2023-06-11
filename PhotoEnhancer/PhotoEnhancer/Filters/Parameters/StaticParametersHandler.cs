using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class StaticParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        static PropertyInfo[] properties;
        static ParameterInfo[] descriptions;

        static StaticParametersHandler()
        {
            properties = typeof(TParameters)
                .GetProperties()
                .Where(p => p.GetCustomAttributes<ParameterInfo>().Count() > 0)
                .ToArray();

            descriptions = typeof(TParameters)
                .GetProperties()
                .Select(p => p.GetCustomAttributes<ParameterInfo>())
                .Where(a => a.Count() > 0)
                .SelectMany(a => a)
                .Cast<ParameterInfo>()
                .ToArray();
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();

            if (properties.Length != values.Length)
                throw new ArgumentException();

            for (var i = 0; i < properties.Length; i++)
            {
                var propertyType = properties[i].PropertyType;
                var convertedValue = Convert.ChangeType(values[i], propertyType);
                properties[i].SetValue(parameters, convertedValue);
            }

            return parameters;
        }


        public ParameterInfo[] GetDescriptions() => descriptions;
    }
}
