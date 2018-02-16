using System;

namespace Assets.Scripts.Core.ViewModel.Properties
{
    public interface IProperty
    {
        object Value { get; }

        event Action OnChange;
    }

    public interface IProperty<out T> : IProperty
    {
        new T Value { get; }

        new event Action OnChange;
    }
}
