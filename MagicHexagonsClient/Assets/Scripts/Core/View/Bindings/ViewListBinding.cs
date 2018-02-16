using System;
using System.Collections.Generic;
using Assets.Scripts.Core.ViewModel;
using Assets.Scripts.Core.ViewModel.Properties;
using UnityEngine;

namespace Assets.Scripts.Core.View.Bindings
{
    public class ViewListBinding : BaseBinding
    {
        public string Path;

        public GameObject Prefab;

        private IProperty _property;

        private Queue<GameObject> _list = new Queue<GameObject>();
        private Queue<GameObject> _listToDestroy = new Queue<GameObject>();

        private Func<List<IViewModel>> _getter;

        protected override void Unbind()
        {
            _getter = null;
            Unsubscribe(ref _property);
        }

        protected override void Bind()
        {
            _property = FindProperty(Path);
            if (_property == null) return;
            _getter = () => ((Property<List<IViewModel>>) _property).Value;
            _property.OnChange += OnChange;
        }


        protected override void OnChange()
        {
            var value = _getter();
            _listToDestroy = _list;
            _list = new Queue<GameObject>();
            foreach (var item in value)
            {
                if (_listToDestroy.Count > 0)
                {
                    var prefab = _listToDestroy.Dequeue();
                    var view = prefab.GetComponent<ItemView>();
                    view.Set(item);
                    _list.Enqueue(prefab);
                }
                else
                {
                    var prefab = Instantiate(Prefab, CachedTransform);
                    var view = prefab.GetComponent<ItemView>();
                    view.Set(item);
                    _list.Enqueue(prefab);
                }
            }

            foreach (var item in _listToDestroy)
                Destroy(item);
            base.OnChange();
        }
    }
}
