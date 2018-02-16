using System;

namespace Assets.Scripts.Core.ViewModel.Properties
{
    class BindingArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public BindingArgs(T value)
        {
            Value = value;
        }
    }
}
