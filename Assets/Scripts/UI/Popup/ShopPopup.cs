using Ads;
using GoogleMobileAds.Api;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace UI.Popup
{
    public class ShopPopup : BasePopup
    {
        [SerializeField] private Button backBtn;
        [SerializeField] private Button watchAdsBtn;

        public override void Init()
        {
            base.Init();
            
            backBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                Hide();
                popupManager.GetPopup("Game").Show();
            });
            
            watchAdsBtn.onClick.AddListener(() =>
            {
                ads.ShowRewardVideo(() =>
                {
                    Datas.Datas.Brain++;
                    var gamePopup = popupManager.GetPopup("Game") as GamePopup;
                    gamePopup.UpdateUi();
                });
                OnClickSound();
            });
        }

        public override void Hide()
        {
            OnLeftPopup();
        }

        public void GetBrains(int brains)
        {
            Datas.Datas.Brain += brains;
            var gamePopup = popupManager.GetPopup("Game") as GamePopup;
            gamePopup.UpdateUi();
        }

        public void RemoveAds()
        {
            Datas.Datas.RemoveAds = true;
        }
    }
}