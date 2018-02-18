using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Game.ViewModel
{
    public class MainViewModel : SimpleViewModel
    {
        public void Login()
        {
            AppViewModel.AppView.OpenForm(FormType.LoginForm);
        }

        public void SingUp()
        {
            AppViewModel.AppView.OpenForm(FormType.SignUpForm);
        }
    }
}
