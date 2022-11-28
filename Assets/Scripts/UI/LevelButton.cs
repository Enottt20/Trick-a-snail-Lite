using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Text numberString;
        [SerializeField] private int levelNumber;
        [SerializeField] private GameObject closeLevel;
        [SerializeField] private GameObject pinkFrame;

        [Inject] private Audio _audio;
    
        private void Start()
        {
            Init();
        }
    
        /// <param name="state">включить или выключить рамку</param>
        public void PinkFrameInput(bool state)
        {
            pinkFrame.SetActive(state);
        }
    
        private bool IsUnlock()
        {
            if (Datas.Datas.MaxLevel+1 >= levelNumber)
            {
                return true;
            }

            return false;
        }

        private void Init()
        {
            numberString.text = levelNumber.ToString();

            if (IsUnlock())
            {
                closeLevel.SetActive(false);
            
                GetComponent<Button>().onClick.AddListener(() => 
                {
                    SceneManager.LoadScene(levelNumber);
                    _audio.PlaySound(_audio.clickSound);
                });
            }
        }
    }
}
