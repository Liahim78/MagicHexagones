using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Game.ViewModel
{
    public class CreateGameViewModel : SimpleViewModel
    {
        public void Back()
        {
            AppViewModel.AppView.OpenForm(FormType.GamesForm);
        }

        public void Create()
        {
            AppViewModel.AppView.OpenForm(FormType.StartGameForm);
        }
    }
}
