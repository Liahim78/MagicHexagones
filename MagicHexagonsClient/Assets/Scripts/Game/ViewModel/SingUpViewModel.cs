using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;
using Assets.Scripts.Core.ViewModel.Properties;
using UnityEngine;

namespace Assets.Scripts.Game.ViewModel
{
   public class SingUpViewModel : SimpleViewModel
    {
        public readonly Property<string> Login = new Property<string>();
        public readonly Property<string> Password = new Property<string>();
        public  readonly Property<string> RepeatPassword = new Property<string>();

        public void Submit()
        {
            Debug.Log("Login " + Login + "| Password " + Password + "| RepeatPassword " + RepeatPassword);
        }

        public void Back()
        {
            AppViewModel.AppView.OpenForm(FormType.MainForm);
        }
    }
}
