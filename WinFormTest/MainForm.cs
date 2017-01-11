using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTest.Properties;

namespace WinFormTest
{
    public partial class MainForm : Form
    {
        #region Constants

        private const bool SHOW_FPS =
#if DEBUG
                true
#else
            false
#endif
            ;

        private const int SNOW_DENSITY = 200;
        private const int MIN_SNOW_ZINDEX = 7;
        private const int MAX_SNOW_ZINDEX = 20;

        private const string FPS_FONT_NAME = "Impact";
        

        #endregion

        #region Fields

        private Font _fpsFont;
        private FrameCounter _frameCounter;
        private IList<SnowFlake> _snowFlakes;
        private Random _random;
        private Image _snowFlakeImg;

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            if (SHOW_FPS)
            {
                _frameCounter = new FrameCounter();
                _fpsFont = new Font(new FontFamily(FPS_FONT_NAME), 16f);
            }

            _snowFlakes = new List<SnowFlake>();
            _random = new Random(DateTime.Now.Millisecond);
            _snowFlakeImg = Resources.flake.RemoveColor(Color.FromArgb(0xFF0000));
        }

        #endregion

        #region Override of Form

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                Location = Screen.AllScreens[1].WorkingArea.Location;

                tmrGfx.Start();
            }
            finally
            {
                base.OnLoad(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                DrawSnow(e.Graphics);
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                tmrGfx.Stop();
            }
            finally
            {
                base.OnClosing(e);
            }
        }

        #endregion

        #region Private methods

        private void DrawSnow(Graphics gfx)
        {
            try
            {
                if (_snowFlakes.Count < SNOW_DENSITY && CalculateChance(_random, 10))
                    _snowFlakes.Add(CreateSnowFlake(_random));

                foreach (var snowFlake in _snowFlakes.ToList())
                {
                    snowFlake.Draw(gfx);
                    snowFlake.Location = new PointF(snowFlake.Location.X, snowFlake.Location.Y + snowFlake.Speed);
                    if (snowFlake.Location.Y > Height)
                        _snowFlakes.Remove(snowFlake);
                }
            }
            finally
            {
                if (SHOW_FPS)
                    DrawFps(gfx);
            }
        }

        private SnowFlake CreateSnowFlake(Random random)
        {
            int zindex = random.Next(MIN_SNOW_ZINDEX, MAX_SNOW_ZINDEX);
            return new SnowFlake
            {
                ZIndex = zindex,
                Location = new Point(random.Next(0, Width - zindex), -zindex),
                Image = _snowFlakeImg.ResizeImage(new Size(zindex, zindex))
            };
        }

        private void DrawFps(Graphics gfx)
        {
            var mframe = _frameCounter.CalculateFrameRate().ToString("D");

            var mframeSize = gfx.MeasureString(mframe, _fpsFont);

            gfx.FillRectangle(Brushes.Green, new RectangleF(PointF.Empty, mframeSize));
            gfx.DrawString(mframe, _fpsFont, Brushes.Red, PointF.Empty);
        }
        
        private static bool CalculateChance(Random random, int chance)
        {
            if (chance > 100)
                chance = 100;

            return random.Next(0, 100) <= chance;
        }

        private void DisposeComponents()
        {
            if (_fpsFont != null)
                _fpsFont.Dispose();
        }

        #endregion

        #region Event handlers

        private void tmrGfx_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        #endregion
    }
}
