using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Windows
{
    public class GenericWindow : MonoBehaviour
    {
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
    }
}