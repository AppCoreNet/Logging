using System;

namespace AppCore.Logging
{
    internal class TimestampProvider
    {
        private int _tickCount;
        private DateTimeOffset _timestamp;

        public static TimestampProvider Instance { get; } = new TimestampProvider();

        public DateTimeOffset GetTimestamp()
        {
            int tickCount = Environment.TickCount;

            if (_tickCount != tickCount)
            {
                DateTimeOffset timestamp;
                _timestamp = timestamp = DateTimeOffset.Now;
                _tickCount = tickCount;
                return timestamp;
            }

            return _timestamp;
        }
    }
}
