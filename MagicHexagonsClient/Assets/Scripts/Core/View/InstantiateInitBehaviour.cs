using UnityEngine;

namespace Assets.Scripts.Core.View
{
    public interface IInstantiateInitable
    {
        void InstantiateInit();
    }

    public abstract class InstantiateInitBehaviour : MonoBehaviour, IInstantiateInitable
    {
        protected bool IsStarted { get; private set; }

        protected void OnEnable()
        {
            InstantiateInitController.AddToInit(this);
            OnEnabling();
        }

        protected void Start()
        {
            if (IsStarted)
                return;

            IsStarted = true;
            OnStarting();
        }

        void IInstantiateInitable.InstantiateInit()
        {
            Start();
        }

        protected virtual void OnEnabling()
        {
        }

        protected virtual void OnStarting()
        {
        }
    }
}
