using System;
using System.Text;
using System.Threading;

namespace P01_BillsPaymentSystem.Functionality
{
    public class Loading : IDisposable
    {
        private const string Animation = @"|/-\";
        private readonly TimeSpan animationInterval = TimeSpan.FromSeconds(1.0 / 8);

        private readonly Timer timer;
        private int animationIndex;

        private string currentText = string.Empty;
        private bool disposed;

        public Loading()
        {
            timer = new Timer(TimerHandler);
            if (!Console.IsOutputRedirected)
                ResetTimer();
        }

        public void Dispose()
        {
            lock (timer)
            {
                disposed = true;
                UpdateText(string.Empty);
            }
        }

        private void TimerHandler(object state)
        {
            lock (timer)
            {
                if (disposed) return;

                var text = string.Format("Loading {0}",
                    Animation[animationIndex++ % Animation.Length]);

                UpdateText(text);
                ResetTimer();
            }
        }

        private void UpdateText(string text)
        {
            var outputBuilder = new StringBuilder();
            outputBuilder.Append('\b', currentText.Length);
            outputBuilder.Append(text.Substring(0));
            Console.Write(outputBuilder);
            currentText = text;
        }

        private void ResetTimer()
        {
            timer.Change(animationInterval, TimeSpan.FromMilliseconds(-1));
        }
    }
}
