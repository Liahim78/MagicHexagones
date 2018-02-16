using UnityEngine;

namespace Assets.Scripts.Core.View.Bindings
{
    public class ActivityExternalBinding : ActivityBaseBinding
    {
        public GameObject Target;

        protected override GameObject ActivityTarget
        {
            get { return Target; }
        }
    }
}
