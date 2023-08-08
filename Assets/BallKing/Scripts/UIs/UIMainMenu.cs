using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BallKing
{
    public class UIMainMenu : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _playBtn;
        [SerializeField] private Button _settingsBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _playBtnText;
        [SerializeField] private TextMeshProUGUI _settingsBtnText;


        private void Start()
        {

            _playBtn.onClick.AddListener(() =>
            {
                
            });

            _settingsBtn.onClick.AddListener(() =>
            {
                
            });
        }

        private void OnDestroy()
        {
            _playBtn.onClick.RemoveAllListeners();
            _settingsBtn.onClick.RemoveAllListeners();
        }

    }
}
