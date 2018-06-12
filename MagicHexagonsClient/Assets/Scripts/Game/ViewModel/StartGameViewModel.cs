using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Game.ViewModel
{
    public class StartGameViewModel : SimpleViewModel
    {
        public void Back()
        {
            AppViewModel.AppView.OpenForm(FormType.GamesForm);
        }

        public void Start()
        {
        }
    }
}
