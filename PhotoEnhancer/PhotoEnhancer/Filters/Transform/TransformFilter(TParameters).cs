using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{

    public abstract class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
    where TParameters : IParameters, new()
    {
        ITransformer<TParameters> transformer;

        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            transformer.Initialize(oldSize, parameters);

            var result = new Photo(transformer.ResultSize.Width, transformer.ResultSize.Height);

            for (var x = 0; x < result.Width; x++)
            {
                for (var y = 0; y < result.Height; y++)
                {
                    var oldPoint = transformer.MapPoint(new Point(x, y));

                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            }

            return result;
        }

        public  ParameterInfo[] GetParametersInfo()
        {
            // получение информации об атрибутах параметров
            var properties = typeof(TParameters).GetProperties();

            // массив с информацией о параметрах
            var parameterInfos = properties.Select(p =>
            {
                var attribute = p.GetCustomAttribute<ParameterInfo>();
                return new ParameterInfo
                {
                    Name = attribute.Name,
                    MinValue = attribute.MinValue,
                    MaxValue = attribute.MaxValue,
                    DefaultValue = attribute.DefaultValue,
                    Increment = attribute.Increment
                };
            }).ToArray();

            return parameterInfos;
        }
    }
    
}
