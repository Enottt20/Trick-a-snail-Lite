using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ads
{
    public interface IInitializeAds
    {
        void InitializeAds();
    }
    
    public interface IRewardAd : IInitializeAds
    {
        void LoadRewardVideo();
        bool IsRewardVideoAvailable();
        void ShowRewardVideo(Action complete);
    }
    
    public interface IInterstitial : IInitializeAds
    {
        void LoadInterstitial();
        bool IsInterstitialAvailable();
        void ShowInterstitial(Action complete = null);
    }
    
    public interface IBanner : IInitializeAds
    {
        void LoadBanner();
        bool IsBannerAvailable();
        void ShowBanner();
        void HideBanner();
    }

    public enum AdsType
    {
        admob,
        unityAds
    }
}