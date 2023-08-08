using UnityEngine;

namespace BallKing
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public UIMainMenu UIMainMenu;
        public UISettings UISettings;
 


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CloseAll();
            DisplayMainMenu(true);
        }

        public void CloseAll()
        {
            DisplayMainMenu(false);
            DisplaySettingsMenu(false);
        }

        public void DisplayMainMenu(bool isActive)
        {
            UIMainMenu.DisplayCanvas(isActive);
        }

        public void DisplaySettingsMenu(bool isActive)
        {
            UISettings.DisplayCanvas(isActive);
        }
    }
}
