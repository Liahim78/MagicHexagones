using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Game.ViewModel
{
    public class UserRoomViewModel: SimpleViewModel
    {
        public void Rating()
        {
            AppViewModel.AppView.OpenForm(FormType.RatingForm);
        }

        public void ToBattle()
        {
            AppViewModel.AppView.OpenForm(FormType.GamesForm);
        }
    }
}
