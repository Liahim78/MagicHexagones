using UnityEngine;

namespace Assets.Scripts.Core.View.Bindings
{
    public abstract class ActivityBaseBinding : BooleanBinding
    {
        protected abstract GameObject ActivityTarget { get; }

        protected override void ApplyNewValue(bool newValue)
        {
            if (ActivityTarget != null)
                ActivityTarget.SetActive(newValue);
            else
                Debug.LogWarning("ActivityTarget not found", gameObject);
        }
    }
}
