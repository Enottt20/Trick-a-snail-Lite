using Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Popup
{
    public class ScrollViewPopup : BasePopup
    {

        public override void Show()
        {
            OnLeftPopup(0);
            base.Show();
        }

        public override void Hide()
        {   
            OnLeftPopup();
        }

        [SerializeField] private Button backBtn;
        [SerializeField] private Button openSettingsBtn;

        public override void Init()
        {
            base.Init();
            
            backBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                popupManager.GetPopup("Game").Show();
                Hide();
            });
            
            openSettingsBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                popupManager.GetPopup("Settings").Show();
                base.Hide();
            });
        }
    }
}