using System;
using Assets.Scripts.Core.ViewModel.Properties;
using UnityEngine;

namespace Assets.Scripts.Core.View.Bindings
{
    public abstract class BaseBinding : InstantiateInitBehaviour, IBinding
    {
        public event Action OnBindingValueProcessed;

        protected virtual bool CanUpdateContext
        {
            get { return IsStarted && CachedGameObj.activeSelf && CachedGameObj.activeInHierarchy && enabled; }
        }

        protected virtual bool CallOnChangeOnUpdateContext
        {
            get { return true; }
        }

        private IView _view;

        protected bool ContextUpdating { get; private set; }

        private bool _contextDirty;
        private bool _viewRegistered;

        private GameObject _cachedGameObj;

        protected GameObject CachedGameObj
        {
            get { return _cachedGameObj ?? (_cachedGameObj = gameObject); }
        }

        private Transform _cachedTransform;

        protected Transform CachedTransform
        {
            get { return _cachedTransform ?? (_cachedTransform = CachedGameObj.transform); }
        }

        private void Awake()
        {
            OnAwake();
        }

        protected sealed override void OnStarting()
        {
            OnStart();
            UpdateContext();
        }

        protected sealed override void OnEnabling()
        {
            LazyContextUpdate();
            OnEnabled();
        }

        private void OnDestroy()
        {
            Unbind();
            OnDestroyed();
        }

        public void ResetContext()
        {
            Unbind();
        }

        public void UpdateContext()
        {
            if (!this)
                return;

            ContextUpdating = true;

            Unbind();

            if (TryPostponeContextUpdate())
                return;

            RegisterDataContexts();

            Bind();
            if (CallOnChangeOnUpdateContext)
                OnChange();
            ContextUpdating = false;
        }

        protected virtual void OnEnabled()
        {
        }

        protected virtual void OnAwake()
        {
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnDestroyed()
        {
        }

        protected virtual void Bind()
        {
        }

        protected virtual void Unbind()
        {
        }

        protected virtual void OnChange()
        {
            RaiseOnBindingValueProcessed();
        }

        protected void Subscribe(IProperty p)
        {
            if (p != null)
                p.OnChange += OnChange;
        }

        protected void Subscribe<T>(IProperty p)
        {
            if (p != null)
                p.OnChange += OnChange;
        }

        protected void Unsubscribe(ref IProperty p)
        {
            if (p == null) return;
            p.OnChange -= OnChange;
            p = null;
        }

        protected void Unsubscribe<T>(ref IProperty p)
        {
            if (p == null) return;
            p.OnChange -= OnChange;
            p = null;
        }

        protected IProperty FindProperty(string path)
        {
            if (_view.ViewModel != null) return _view.ViewModel.FindProperty(path);
            Debug.Log(_view + " " + path);
            return new Property();

        }

        protected IProperty<T> FindProperty<T>(string path)
        {
            return FindProperty(path) as IProperty<T>;
        }

        protected Delegate FindMethod(string path)
        {
            return _view.ViewModel.FindMethod(path);
        }

        private void LazyContextUpdate()
        {
            if (!_contextDirty || !CanUpdateContext) return;
            _contextDirty = false;
            UpdateContext();
        }

        private bool TryPostponeContextUpdate()
        {
            if (CanUpdateContext) return false;
            return _contextDirty = true;
        }

        protected void RegisterDataContexts()
        {
            if (_viewRegistered)
                return;

            _viewRegistered = true;

            var current = CachedTransform;
            var view = current.GetComponent<IView>();
            while (view == null && current.parent != null)
            {
                current = current.parent;
                view = current.GetComponent<IView>();
            }

            _view = view;
            if (_view != null)
                _view.OnChange += UpdateContext;
        }

        private void RaiseOnBindingValueProcessed()
        {
            if (OnBindingValueProcessed != null)
                OnBindingValueProcessed();
        }
    }
}
