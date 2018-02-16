using MagicHexagonsModel.Models;

namespace Assets.Scripts.Core.ViewModel
{
    public class RefreshableViewModel : SimpleViewModel, IRefreshableViewModel
    {
        public RefreshableViewModel() :
            this(false)
        {
        }

        public RefreshableViewModel(bool flag)
        {
            if (flag)
                return;
            OnBegin();
        }

        protected void OnBegin()
        {
            var user = new User(); //AppModel.GetUser();
            Instantiate(user);
            Subscribe(user);
            Refresh(user);
        }

        public virtual void Refresh(User user)
        {

        }


        public virtual void Instantiate(User user)
        {
        }

        public virtual void Subscribe(User user)
        {
        }

        public virtual void Normolize(User user)
        {
        }

        public virtual void Unsubscribe(User user)
        {
        }
    }
}