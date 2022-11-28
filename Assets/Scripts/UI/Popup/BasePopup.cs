using System;
using System.Collections;
using Ads;
using DG.Tweening;
using Managers;
using UnityEngine;
using Zenject;

namespace UI.Popup
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class BasePopup : MonoBehaviour
    {
        [Inject] protected Audio audio;
        [Inject] protected PopupManager popupManager;
        [Inject] protected Advertising ads;

        private RectTransform rectTransform;

        private void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public virtual void Show()
        {
            OnMiddlePopup();
            ads.ShowBanner();
        }

        public virtual void Hide()
        {
            OnRightPopup();
        }
        
        protected void OnLeftPopup(float delay= 0.33f)
        {
            rectTransform.DOLocalMoveX(-rectTransform.rect.width, delay);
        }

        protected void OnMiddlePopup(float delay= 0.33f)
        {
            rectTransform.DOLocalMoveX(0, delay);
        }

        protected void OnRightPopup(float delay = 0.33f)
        {
            rectTransform.DOLocalMoveX(rectTransform.rect.width, delay);
        }
        
        protected void OnClickSound()
        {
            audio.PlaySound(audio.clickSound);
        }

    }
}