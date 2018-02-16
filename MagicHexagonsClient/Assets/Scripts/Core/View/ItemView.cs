using System;
using Assets.Scripts.Core.ViewModel;
using MagicHexagonsModel.Models;
using UnityEngine;

namespace Assets.Scripts.Core.View
{
    public class ItemView : MonoBehaviour, IView
    {
        public IViewModel ViewModel { get; private set; }

        public event Action OnChange;

        public void Set(IViewModel viewModel)
        {
            ViewModel = viewModel;
            if (OnChange != null)
                OnChange();
        }

        private void OnDestroy()
        {
            var refreshViewModel = ViewModel as IRefreshableViewModel;
            if (refreshViewModel != null)
                refreshViewModel.Unsubscribe(new User());
        }
    }
}
