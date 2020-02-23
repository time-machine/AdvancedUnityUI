using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Windows
{
    public class GenericWindow : MonoBehaviour
    {
        public static WindowManager manager;
        public global::Windows nextWindow;
        public global::Windows previousWindow;

        public GameObject FirstSelected;

        protected EventSystem EventSystem => GameObject.Find("EventSystem").GetComponent<EventSystem>();

        public virtual void OnFocus()
        {
            EventSystem.SetSelectedGameObject(FirstSelected);
        }

        protected virtual void Display(bool value)
        {
            gameObject.SetActive(value);
        }

        public virtual void Open()
        {
            Display(true);
            OnFocus();
        }

        public virtual void Close()
        {
            Display(false);
        }

        protected virtual void Awake()
        {
            Close();
        }

        public void OnNextWindow()
        {
            manager.Open((int)nextWindow - 1);
        }

        public void OnPreviousWindow()
        {
            manager.Open((int)previousWindow - 1);
        }
    }
}