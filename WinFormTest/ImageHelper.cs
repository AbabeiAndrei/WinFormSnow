using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{
    public static class ImageHelper
    {
        public static Image RemoveColor(this Image img, Color color)
        {
            if (img == null)
                return null;

            var bmp = new Bitmap(img);

            for (int i = 0; i < img.Width; i++)
            for (int j = 0; j < img.Height; j++)
            {
                var mcol = bmp.GetPixel(i, j);
                if (mcol.R == color.R && mcol.G == color.G && mcol.B == color.B)
                    bmp.SetPixel(i, j, Color.Transparent);
            }

            return bmp;
        }

        public static Image ResizeImage(this Image img, Size newSize)
        {
            if (img == null)
                return null;

            return new Bitmap(img, newSize);
        }
    }
}
