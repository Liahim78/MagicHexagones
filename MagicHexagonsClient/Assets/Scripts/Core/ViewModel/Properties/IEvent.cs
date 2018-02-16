using System;

namespace Assets.Scripts.Core.ViewModel.Properties
{
    public interface IEvent
    {
        event Action OnChange;
    }
}
