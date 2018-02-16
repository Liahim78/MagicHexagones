using System;
using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Core.View
{
    public interface IView
    {
        event Action OnChange;
        IViewModel ViewModel { get; }
    }
}
