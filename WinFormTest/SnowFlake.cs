using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{
    public class SnowFlake
    {
        #region Constants

        protected const float FACTOR_SPEED = 0.05f;
        
        #endregion

        #region Properties

        public PointF Location { get; set; }

        public int ZIndex { get; set; }

        public float Speed => ZIndex * FACTOR_SPEED;

        public Image Image { get; set; }

        #endregion

        #region Public methods

        public void Draw(Graphics gfx)
        {
            if(Image == null)
                return;

            gfx.DrawImage(Image, Location);
        }

        #endregion
    }
}
