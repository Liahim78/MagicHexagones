using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Game.ViewModel
{
    public class GamesViewModel : SimpleViewModel
    {
        public void Back()
        {
            AppViewModel.AppView.OpenForm(FormType.UserRoomForm);
        }

        public void Create()
        {
            AppViewModel.AppView.OpenForm(FormType.CreateGameForm);
        }

        public void OnGame()
        {
            AppViewModel.AppView.OpenForm(FormType.StartGameForm);
        }
    }
}
