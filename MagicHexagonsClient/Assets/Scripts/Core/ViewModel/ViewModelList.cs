using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core.ViewModel.Properties;

namespace Assets.Scripts.Core.ViewModel
{
    public class ViewModelList<T, TR> : Property<List<IViewModel>> where T : ISettable<TR>, IViewModel, new()
    {
        public override event Action OnChange;

        private readonly List<IViewModel> _list = new List<IViewModel>();

        public override List<IViewModel> Value
        {
            get { return _list; }
        }

        public void Set(IList<TR> list)
        {
            if (Equals(list))
                return;
            Value.Clear();
            foreach (var item in list)
            {
                var viewModel = new T();
                viewModel.Set(item);
                Value.Add(viewModel);
            }

            if (OnChange != null)
                OnChange();
        }

        private bool Equals(IList<TR> list)
        {
            if (list.Count != _list.Count)
                return false;
            return !_list.Where((t, i) => !t.Equals(list[i])).Any();
        }
    }
}
