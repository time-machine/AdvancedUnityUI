using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Windows
{
    public class StartWindow : GenericWindow
    {
        public Button ContinueButton;

        protected override void Awake()
        {
        }

        void Start()
        {
            Open();
        }

        public override void Open()
        {
            var canContinue = true;
            ContinueButton.gameObject.SetActive(canContinue);
            if (ContinueButton.gameObject.activeSelf)
            {
                FirstSelected = ContinueButton.gameObject;
            }
            base.Open();
        }

        public void NewGame()
        {
            Debug.Log("New Game Pressed");
        }

        public void Continue()
        {
            Debug.Log("Continue Pressed");
        }

        public void Options()
        {
            Debug.Log("Options Pressed");
        }
    }
}