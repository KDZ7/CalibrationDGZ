using System.Windows.Threading;

namespace modus.Common.UtilBox
{
    public abstract class TimerHdle
    {
        private ulong _Tick;
        private DispatcherTimer _DispatcherTimer;
        protected bool isRunning => _DispatcherTimer?.IsEnabled ?? false;
        public TimerHdle()
        {
            _Tick = 0;
            _DispatcherTimer = new DispatcherTimer();
            _DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _DispatcherTimer.Tick += TimerTick;
            _DispatcherTimer.Start();
        }
        private void TimerTick(object? sender, EventArgs e)
        {
            _Tick++;
            if (_Tick % 1 == 0)
                Second();
            if (_Tick % 60 == 0)
                Minute();
            if (_Tick % 3600 == 0)
                Hour();
        }
        protected void Stop()
        {
            _DispatcherTimer.Stop();
        }
        protected void Restart()
        {
            Stop();
            _Tick = 0;
            _DispatcherTimer.Start();
        }
        protected virtual void Second() { }
        protected virtual void Minute() { }
        protected virtual void Hour() { }
    }
}
