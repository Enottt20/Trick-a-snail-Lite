using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace Ads.Advertising_networks
{
    [System.Serializable]
    public class AdMob : IRewardAd, IInterstitial
    {
        private InterstitialAd interstitial;

        private RewardedAd rewarded;
        
        private EventHandler<Reward> lastEvent;

        [SerializeField] private string interstitialAd = "ca-app-pub-3940256099942544/1033173712";
        [SerializeField] private string rewardedAd = "ca-app-pub-5771758930667573/1519488317";
        
        public void InitializeAds()
        {
            LoadInterstitial();
            LoadRewardVideo();
        }

        public void LoadRewardVideo()
        {
            rewarded = new RewardedAd(rewardedAd);
            
            AdRequest request2 = new AdRequest.Builder().Build();
            
            rewarded.LoadAd(request2);
        }

        public bool IsRewardVideoAvailable()
        {
            return rewarded.IsLoaded();
        }

        public void ShowRewardVideo(Action complete)
        {
            if (lastEvent != null) rewarded.OnUserEarnedReward -= lastEvent;
            
            lastEvent = (sender, reward) => complete?.Invoke();
            
            rewarded.OnUserEarnedReward += lastEvent;

            if (IsRewardVideoAvailable()) 
                rewarded.Show();
            else
                LoadRewardVideo();
        }

        public void LoadInterstitial()
        {
            interstitial = new InterstitialAd(interstitialAd);
            
            AdRequest request = new AdRequest.Builder().Build();
            
            interstitial.LoadAd(request);
        }

        public bool IsInterstitialAvailable()
        {
            return interstitial.IsLoaded();
        }

        public void ShowInterstitial(Action complete)
        {
            if(Datas.Datas.RemoveAds) return;
            
            if (IsInterstitialAvailable()) 
                interstitial.Show();
            else
                LoadInterstitial();
        }
    }
}