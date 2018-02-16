using System;
using System.Collections.Generic;
using Assets.Scripts.Core.ViewModel.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.Bindings
{
    public class DictionarySpriteBinding : BaseBinding
    {
        public string Path;
        public Image Image;

        public int[] Indexes;
        public Sprite[] Imagies;

        private Dictionary<int, Sprite> _dictionary = new Dictionary<int, Sprite>();

        private IProperty _property;

        private Func<int> _getter;

        protected override void OnStart()
        {
            for (var i = 0; i < Indexes.Length; i++)
                _dictionary.Add(Indexes[i], Imagies[i]);

            base.OnStart();
        }

        protected override void Unbind()
        {
            _getter = null;
            Unsubscribe(ref _property);
        }

        protected override void Bind()
        {
            _property = FindProperty(Path);
            if (_property == null) return;
            _getter = () => ((Property<int>) _property).Value;
            _property.OnChange += OnChange;
        }

        protected override void OnChange()
        {
            Image.sprite = _dictionary[_getter()];
            base.OnChange();
        }
    }
}
