using MagicHexagonsModel.Models;
using MagicHexagonsModel.Wrappers;

namespace Assets.Scripts.Core.Model
{
    public static class AppModel
    {
        public static bool IsActive { get { return _userWrapper != null && _userWrapper.User != null; } }
        
        public static long UserId { get; private set; }

        private static UserWrapper _userWrapper;

        public static UserReadGuard ReadUser()
        {
            return new UserReadGuard(_userWrapper);
        }

        public static UserEditGuard EditUser()
        {
            return new UserEditGuard(_userWrapper);
        }

        public static UserReadGuard ReadUserOrUseCurrent()
        {
            return new UserReadGuard(_userWrapper, true);
        }

        public static UserEditGuard EditUserOrUseCurrent()
        {
            return new UserEditGuard(_userWrapper, true);
        }
    }
}