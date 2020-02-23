using Assets.Scripts.Windows;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class WindowManager : MonoBehaviour
    {
        [HideInInspector]
        public GenericWindow[] windows;
        public int currentWindowId;
        public int defaultWindowId;

        public GenericWindow GetWindow(int value)
        {
            return windows[value];
        }

        private void ToggleVisibility(int value)
        {
            for (var i = 0; i < windows.Length; i++)
            {
                var win = windows[i];
                if (i == value)
                {
                    win.Open();
                }
                else if (win.gameObject.activeSelf)
                {
                    win.Close();
                }
            }
        }

        public GenericWindow Open(int value)
        {
            if (value < 0 || value > windows.Length)
            {
                return null;
            }

            currentWindowId = value;
            ToggleVisibility(currentWindowId);

            return GetWindow(currentWindowId);
        }

        void Start()
        {
            GenericWindow.manager = this;
            Open(defaultWindowId);
        }
    }
}