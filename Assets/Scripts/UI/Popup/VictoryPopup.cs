using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.Popup
{
    public class VictoryPopup : BasePopup
    {
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private Button continueBtn;
        [SerializeField] private AudioClip showSound;
        [SerializeField] private Text descriptionTxt;

        public override void Init()
        {
            base.Init();
            
            UpdateUi();
            
            continueBtn.onClick.AddListener(() =>
            {
                OnClickSound();

                if (SceneManager.GetActiveScene().buildIndex > Datas.Datas.MaxLevel)
                {
                    Datas.Datas.MaxLevel++;
                }

                //если есть следующая сцена то открываем ее если нет то открываем первую
                if (SceneManager.sceneCountInBuildSettings-1 > SceneManager.GetActiveScene().buildIndex)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            });
        }

        private void UpdateUi()
        {
            descriptionTxt.text = Description();
        }

        private string Description()
        {
            return "Level " + SceneManager.GetActiveScene().buildIndex + " completed";
        }
        
        public override void Show()
        {
            mainCanvas.sortingLayerName = "upper";
            audio.PlaySound(showSound);
            gameObject.SetActive(true);
        }
    }
}