using Assets.Scripts.Core.ViewModel;

namespace Assets.Scripts.Core.View
{
    public class Form<T> : ItemView where T : IViewModel, new()
    {
        void Awake()
        {
            Set(new T());
        }
    }
}
