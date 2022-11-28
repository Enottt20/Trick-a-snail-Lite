using Level;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.Popup
{
    public class GamePopup : BasePopup
    {
        [SerializeField] private Text brainsTxt;
        [SerializeField] private Text titleTxt;
        [SerializeField] private Text levelNumberTxt;
        
        [SerializeField] private Button openScrollViewBtn;
        [SerializeField] private Button openShopBtn;
        [SerializeField] private Button restartBtn;
        [SerializeField] private Button adviceBtn;
        [SerializeField] private Button skipLevelBtn;
        [SerializeField] private AdvicePopup advicePopup;
        [SerializeField] private LevelData levelData;

        public override void Init()
        {
            base.Init();

            UpdateUi();

            AdvicePopupUpdateUi();
            
            openScrollViewBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                popupManager.GetPopup("ScrollView").Show();
                Hide();
            });
            
            openShopBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                popupManager.GetPopup("Shop").Show();
                Hide();
            });
            
            restartBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
            
            adviceBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                if (Datas.Datas.Brain >= Datas.Datas.AdvicePrice)
                {
                    //Деньги есть, показываем совет
                    advicePopup.Show();
                    Datas.Datas.Brain -= Datas.Datas.AdvicePrice;
                    UpdateUi();

                }
                else
                {
                    //Денег нет по этому открываем магаз
                    popupManager.GetPopup("Shop").Show();
                    Hide();
                }
            });
            
            skipLevelBtn.onClick.AddListener(() =>
            {
                OnClickSound();
                
                //Если следующая сцена открыта то без проблем переходим на нее
                if (Datas.Datas.MaxLevel + 1 > SceneManager.GetActiveScene().buildIndex)
                {
                    if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else
                    {
                        SceneManager.LoadScene(1);
                    }
                    
                    return;
                }

                if (Datas.Datas.Brain >= Datas.Datas.SkipLevelPrice)
                {
                    //Если следующая сцена не открыта и у нас есть нужно колво монет то открываем следующую сцену
                    Datas.Datas.Brain -= Datas.Datas.SkipLevelPrice;

                    //Если это последняя сцена то перекидываем на первую
                    if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
                    {
                        Datas.Datas.MaxLevel += 1;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    else
                    {
                        SceneManager.LoadScene(1);
                    }
                }
                else
                {
                    //Следующая сцена закрыта и денег не достаточно, открываем магаз
                    popupManager.GetPopup("Shop").Show();
                    Hide();
                }
            });
        }
        
        public void UpdateUi()
        {
            if(string.IsNullOrEmpty(levelData.levelTitle)) Debug.LogError("Нет названия уровня");
            
            brainsTxt.text = Datas.Datas.Brain.ToString();
            titleTxt.text = levelData.levelTitle;
            levelNumberTxt.text = "Lv." + SceneManager.GetActiveScene().buildIndex;
        }

        private void AdvicePopupUpdateUi()
        {
            if(string.IsNullOrEmpty(levelData.levelTitle)) Debug.LogError("Нет названия подсказки");
            advicePopup.Title = levelData.adviceTitle;
            if(string.IsNullOrEmpty(levelData.levelTitle)) Debug.LogError("Нет описания подсказки");
            advicePopup.Description = levelData.adviceDescription;
            
            advicePopup.UpdateUi();
        }
        
    }
}