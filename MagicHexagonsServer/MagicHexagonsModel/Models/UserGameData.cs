using System.Diagnostics;

namespace MagicHexagonsModel.Models
{
    public class UserGameData: IUpdatable<UserGameData>
    {
        public void Update(UserEditGuard user, UserGameData other)
        {
        }

        public int CalcHash()
        {
            unchecked
            {
                return 0;
            }
        }
    }
}
