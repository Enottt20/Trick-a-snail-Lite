using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.Popup
{
    public class SettingsPopup : BasePopup
    {
        [SerializeField] private Button backBtn;
        [SerializeField] private Button soundBtn;
        [SerializeField] private Button musicBtn;
        [SerializeField] private Button vibrationBtn;
        [SerializeField] private Button rateAppBtn;
        [SerializeField] private Button shareAppBtn;
        [SerializeField] private GameObject offSound;
        [SerializeField] private GameObject offMusic;
        [SerializeField] private GameObject offVibration;

        public override void Init()
        {
            base.Init();
            
            backBtn.onClick.AddListener(() =>
            {
                popupManager.GetPopup("Game").Show();
                Hide();
                OnClickSound();
            });
            
            soundBtn.onClick.AddListener(OnClickSound);
            soundBtn.onClick.AddListener(sound);
            musicBtn.onClick.AddListener(OnClickSound);
            musicBtn.onClick.AddListener(music);
            vibrationBtn.onClick.AddListener(OnClickSound);
            vibrationBtn.onClick.AddListener(vibration);
            rateAppBtn.onClick.AddListener(OnClickSound);
            rateAppBtn.onClick.AddListener(rateApp);
            shareAppBtn.onClick.AddListener(OnClickSound);
            shareAppBtn.onClick.AddListener(shareApp);
            
            if (!Datas.Datas.Sound) offSound.SetActive(true);
            if (!Datas.Datas.Music) offMusic.SetActive(true);
            if (!Datas.Datas.Vibration) offVibration.SetActive(true);
        }

        public override void Show()
        {
            OnLeftPopup(0);
            base.Show();
        }

        public override void Hide()
        {
            OnLeftPopup();
        }

        #region private methods

        private void vibration()
        {
            if (!Datas.Datas.Vibration)
            {
                offVibration.SetActive(false);
                Datas.Datas.Vibration = true;
            }
            else
            {
                offVibration.SetActive(true);
                Datas.Datas.Vibration = false;
            }
        }

        private void music()
        {
            if (!Datas.Datas.Music)
            {
                offMusic.SetActive(false);
                Datas.Datas.Music = true;
            }
            else
            {
                offMusic.SetActive(true);
                Datas.Datas.Music = false;
            }

            audio.UpdateStates();
        }

        private void sound()
        {
            if (!Datas.Datas.Sound)
            {
                offSound.SetActive(false);
                Datas.Datas.Sound = true;
            }
            else
            {
                offSound.SetActive(true);
                Datas.Datas.Sound = false;
            }

            audio.UpdateStates();
        }
        private void rateApp()
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
        }

        private void shareApp()
        {
            NativeShare nativeShare = new NativeShare();
            nativeShare.SetText("https://play.google.com/store/apps/details?id=" + Application.identifier).Share();
        }

        private void restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion
        
    }
}