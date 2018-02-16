using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MagicHexagonsModel.Models
{
    public interface IUpdatable<T>
    {
        void Update(UserEditGuard user, T other);
        int CalcHash();
    }

    public static class UpdatableUtils
    {
        public static bool Update<T>(ref T data, T other)
        {
            if (!typeof(T).IsValueType)
            {
                if (ReferenceEquals(data, null))
                {
                    data = other;
                    return !ReferenceEquals(other, null);
                }
            }

            if (!EqualityComparer<T>.Default.Equals(data, other))
            {
                data = other;
                return true;
            }

            return false;
        }

        public static void Update<T>(UserEditGuard user, ref T data, T other, Action<UserEditGuard> onReplaced = null)
            where T : class, IUpdatable<T>
        {
            if (other == null || data == null)
            {
                var callReplaced = (other != null) ^ (data != null);
                data = other;

                if (callReplaced && onReplaced != null)
                    onReplaced(user);
                return;
            }

            var sw = Stopwatch.StartNew();

            data.Update(user, other);

            var ms = sw.ElapsedMilliseconds;
            //if (ms > 30)
                //Log.WarnFormat("{0} update (too slow): {1} ms", typeof(T).Name, ms);
        }
    }
}