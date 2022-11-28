using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popup
{
    public class AdvicePopup : BasePopup
    {
        [SerializeField] private Button hidePopupBtn;
        [SerializeField] private Text titleTxt;
        [SerializeField] private Text descriptionTxt;
        [SerializeField] private Canvas mainCanvas;
        
        public string Title { get; set; }
        public string Description { get; set; }
        public override void Init()
        {
            base.Init();
            Hide();

            hidePopupBtn.onClick.AddListener(() =>
            {
                Hide();
                OnClickSound();
            });
        }

        public void UpdateUi()
        {
            titleTxt.text = Title;
            descriptionTxt.text = Description;
        }

        public override void Show()
        {
            //делаем канвас выше что бы отображался над спрайтами
            mainCanvas.sortingLayerName = "upper";
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            mainCanvas.sortingLayerName = "Default";
        }
    }
}