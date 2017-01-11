using System;

namespace WinFormTest
{
    public class FrameCounter
    {
        private int _lastTick;
        private int _lastFrameRate;
        private int _frameRate;

        public int CalculateFrameRate()
        {
            if (Environment.TickCount - _lastTick >= 1000)
            {
                _lastFrameRate = _frameRate;
                _frameRate = 0;
                _lastTick = Environment.TickCount;
            }
            _frameRate++;
            return _lastFrameRate;
        }
    }
}
