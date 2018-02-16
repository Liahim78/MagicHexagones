using MagicHexagonsModel.Models;

namespace Assets.Scripts.Core.ViewModel
{
    public interface IRefreshableViewModel
    {
        void Instantiate(User user);
        void Subscribe(User user);
        void Refresh(User user);
        void Normolize(User user);

        void Unsubscribe(User user);
    }
}
