namespace Assets.Scripts.Core.ViewModel
{
    public interface ISettable<T>
    {
        void Set(T value);

        bool Equal(T parametrs);
    }
}
