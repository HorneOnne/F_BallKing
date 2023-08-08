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
        [SerializeField] private Button _informationBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _recordText;


        private const string PRIVACY_URL = "https://doc-hosting.flycricket.io/ballking-privacy-policy/2954cb82-2353-40e2-af2b-8ebff1eb767b/privacy";

        private void Start()
        {
            LoadRecord();

            _playBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.GameplayScene);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _settingsBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.DisplaySettingsMenu(true);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            _informationBtn.onClick.AddListener(() =>
            {
                Application.OpenURL(PRIVACY_URL);

                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            _playBtn.onClick.RemoveAllListeners();
            _settingsBtn.onClick.RemoveAllListeners();
        }


        private void LoadRecord()
        {
            _recordText.text = GameManager.Instance.BestScore.ToString();
        }

    }
}
