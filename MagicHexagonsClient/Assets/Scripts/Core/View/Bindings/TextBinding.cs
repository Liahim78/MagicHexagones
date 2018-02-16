using System;
using Assets.Scripts.Core.ViewModel.Properties;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.Bindings
{
    public class TextBinding : BaseBinding
    {
        public string Path;

        public Text Text;

        private IProperty _property;

        private Func<string> _getter;

        protected override void Unbind()
        {
            _getter = null;
            Unsubscribe(ref _property);
        }

        protected override void Bind()
        {
            _property = FindProperty(Path);
            if (_property == null) return;
            _getter = () => ((Property<string>) _property).Value;
            _property.OnChange += OnChange;
        }


        protected override void OnChange()
        {
            Text.text = _getter();
            base.OnChange();
        }
    }
}
