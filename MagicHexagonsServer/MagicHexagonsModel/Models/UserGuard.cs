using System;
using System.Diagnostics;
using System.Threading;
using MagicHexagonsModel.Wrappers;

namespace MagicHexagonsModel.Models
{
    public class UserReadGuard : IDisposable
    {
        private const int LockTimeoutMs = 10000; // 10 seconds

        protected UserWrapper Wrapper;

        private static Stopwatch _swProcessing;

        [ThreadStatic] private static UserReadGuard _current;

        public UserReadGuard(UserWrapper wrapper, bool allowNestedContext = false, bool tryEnter = false)
        {
            if (wrapper == null)
                throw new InvalidOperationException("User is not initialized");

            if (_current == null || _current.Wrapper != wrapper)
            {
                // Statistics
                var swWaiting = Stopwatch.StartNew();

                // Lock
                if (tryEnter)
                {
                    if (!Monitor.TryEnter(wrapper))
                        return;
                }
                else if (!Monitor.TryEnter(wrapper, LockTimeoutMs))
                {
                    throw new InvalidOperationException("User lock timeout");
                }

                // Statistics
                swWaiting.Stop();
                if (_swProcessing == null)
                    _swProcessing = Stopwatch.StartNew();
                else
                    _swProcessing.Start();

                // Current
                _current = this;
            }

            // User
            Wrapper = wrapper;

        }
        public virtual void Dispose()
        {
            var wrapper = Wrapper;
            if (wrapper == null)
                return;


            // User
            Wrapper = null;

            if (_current != this) return;
            // Current
            _current = null;
            _swProcessing.Reset();

            // Unlock
            Monitor.Exit(wrapper);
        }
    }

    public class UserEditGuard : UserReadGuard
    {
        [ThreadStatic] private static UserEditGuard _current;
        
        public UserEditGuard(UserWrapper wrapper, bool allowNestedContext = false, bool tryEnter = false)
            : base(wrapper, allowNestedContext, tryEnter)
        {
            if (_current == null)
                _current = this;
        }

        public override void Dispose()
        {
            if (_current == this)
                _current = null;

            base.Dispose();
        }
        public void UpdateOnFullUserRefresh(UserGameData userGameData)
        {
            
        }
    }
}
