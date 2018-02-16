using Assets.Scripts.Core.View.Types;
using Assets.Scripts.Core.ViewModel;
using UnityEngine;

namespace Assets.Scripts.Core.View
{
    public class AppView : MonoBehaviour
    {
        public GameObject Form;
        public GameObject Popups;

        private GameObject _openedForm;
        private GameObject _openedPopup;

        //private readonly string _path = Path.Combine(Application.persistentDataPath, "autorization.json");

        // Use this for initialization
        private void Start()
        {
            AppViewModel.AppView = this;
            //if (File.Exists(_path))
           // {
            //    User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(_path));
            //}
            //else
                OpenForm(FormType.LoginForm);
        }

        private AppView()
        {

        }

        public void OpenForm(FormType formType, object state = null)
        {
            ClosePopup();
            if (_openedForm != null)
            {
                Destroy(_openedForm);
            }
            var prefab = (GameObject)Resources.Load(@"Forms/" + formType.ToString(), typeof(GameObject));
            if (prefab == null)
            {
                Debug.LogError("Prefab" + formType.ToString() + "is null");
                return;
            }
            _openedForm = Instantiate(prefab, Form.transform);
        }

        public void OpenPopup(PopupType popupType, object state = null)
        {
            if (_openedPopup != null)
            {
                Destroy(_openedForm);
            }
            var prefab = (GameObject)Resources.Load(@"Popups/" + popupType.ToString(), typeof(GameObject));
            if (prefab == null)
            {
                Debug.LogError("Prefab" + popupType.ToString() + "is null");
                return;
            }
            _openedPopup = Instantiate(prefab, Popups.transform);
        }

        public void ClosePopup()
        {
            if (_openedPopup != null)
            {
                Destroy(_openedPopup);
                _openedPopup = null;
            }
        }

        public IView GetView(Transform startTransform)
        {
            var current = startTransform;
            var view = current.GetComponent<IView>();
            while (view == null && current.parent != null)
            {
                current = current.parent;
                view = current.GetComponent<IView>();
            }
            return view;
        }
    }
}
