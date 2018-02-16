using System;
using Assets.Scripts.Core.ViewModel.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View.Bindings
{
    class GridSizeBinding : BaseBinding
    {
        private IProperty _sizeX;
        private IProperty _sizeY;

        public string PathX;
        public string PathY;

        private Func<int> _getterSizeX;
        private Func<int> _getterSizeY;

        protected override void OnStart()
        {
            var grid = CachedGameObj.AddComponent<GridLayoutGroup>();
            grid.childAlignment = TextAnchor.MiddleCenter;
            base.OnStart();
        }

        protected override void Unbind()
        {
            _getterSizeX = null;
            _getterSizeY = null;
            Unsubscribe(ref _sizeX);
            Unsubscribe(ref _sizeY);
        }

        protected override void Bind()
        {
            _sizeX = FindProperty(PathX);
            _sizeY = FindProperty(PathY);
            if (_sizeX == null || _sizeY == null) return;
            _getterSizeX = () => ((Property<int>) _sizeX).Value;
            _getterSizeY = () => ((Property<int>) _sizeY).Value;
            _sizeX.OnChange += OnChange;
            _sizeY.OnChange += OnChange;
        }


        protected override void OnChange()
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            var grid = CachedGameObj.GetComponent<GridLayoutGroup>();
            var size = Math.Min(rectTransform.rect.width / _getterSizeX(), rectTransform.rect.height / _getterSizeY());
            if (grid != null)
                grid.cellSize = new Vector2(size, size);
            base.OnChange();
        }
    }
}
