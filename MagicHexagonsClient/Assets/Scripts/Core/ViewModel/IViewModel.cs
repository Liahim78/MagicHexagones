using System;
using Assets.Scripts.Core.ViewModel.Properties;

namespace Assets.Scripts.Core.ViewModel
{
    public interface IViewModel
    {
        IProperty FindProperty(string path);
        Delegate FindMethod(string path);
        void OnDestroy();
    }
}
