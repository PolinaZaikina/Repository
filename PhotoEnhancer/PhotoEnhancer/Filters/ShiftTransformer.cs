using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ShiftTransformer : ITransformer<ShiftParameters>
    {
        private Size originalSize;
        private int shiftPixels;

        public Size ResultSize => new Size(originalSize.Width, originalSize.Height);

        public void Initialize(Size size, ShiftParameters parameters)
        {
            originalSize = size;
            shiftPixels = (int)(size.Height * parameters.ShiftPercentage / 100.0);
        }

        public Point? MapPoint(Point point)
        {
            int newY = (point.Y - shiftPixels + originalSize.Height) % originalSize.Height;
            return new Point(point.X, newY);
        }
        public class ShiftFilter : TransformFilter<ShiftParameters>
        {
            public ShiftFilter() : base("Сдвиг вниз", new ShiftTransformer()) { }
        }

    }
}
