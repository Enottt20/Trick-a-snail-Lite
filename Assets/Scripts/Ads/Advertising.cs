using System;
using Ads.Advertising_networks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Ads
{

    public class Advertising : MonoBehaviour
    {
        [SerializeField] private AdsType currentAdsType;
        
        [Space]
        
        [SerializeField] private AdMob adMob;

        private Advertise baseAds;

        private void Awake()
        {
            if (currentAdsType == AdsType.admob)
            {
                baseAds = new Advertise(adMob);
            }
            
            InitializeAds();
        }

        public void InitializeAds() => baseAds.InitializeAds();

        public void LoadRewardVideo() => baseAds?.LoadRewardVideo();

        public bool? IsRewardVideoAvailable() => baseAds?.IsRewardVideoAvailable();

        public void ShowRewardVideo(Action complete) => baseAds?.ShowRewardVideo(complete);

        public void LoadInterstitial() => baseAds?.LoadInterstitial();

        public bool? IsInterstitialAvailable() => baseAds?.IsInterstitialAvailable();

        public void ShowInterstitial(Action complete = null) => baseAds?.ShowInterstitial(complete);

        public void LoadBanner() => baseAds?.LoadBanner();

        public bool? IsBannerAvailable() => baseAds?.IsBannerAvailable();

        public void ShowBanner() => baseAds?.ShowBanner();

        public void HideBanner() => baseAds?.HideBanner();
    }
    
    public class Advertise : IRewardAd, IInterstitial, IBanner
    {
        private IInitializeAds initializeAds;
        private IRewardAd rewardAd;
        private IInterstitial interstitial;
        private IBanner banner;

        public Advertise(IInitializeAds initializeAds)
        {
            this.initializeAds = initializeAds as IInitializeAds;
            rewardAd = initializeAds as IRewardAd;
            interstitial = initializeAds as IInterstitial;
            banner = initializeAds as IBanner;
        }

        public void InitializeAds() => initializeAds?.InitializeAds();

        public void LoadRewardVideo() => rewardAd?.LoadRewardVideo();

        public bool IsRewardVideoAvailable() => rewardAd.IsRewardVideoAvailable();

        public void ShowRewardVideo(Action complete) => rewardAd?.ShowRewardVideo(complete);

        public void LoadInterstitial() => interstitial?.LoadInterstitial();

        public bool IsInterstitialAvailable() => interstitial.IsInterstitialAvailable();

        public void ShowInterstitial(Action complete = null) => interstitial?.ShowInterstitial(complete);

        public void LoadBanner() => banner?.LoadBanner();

        public bool IsBannerAvailable() => banner.IsBannerAvailable();

        public void ShowBanner() => banner?.ShowBanner();

        public void HideBanner() => banner?.HideBanner();
    }
}