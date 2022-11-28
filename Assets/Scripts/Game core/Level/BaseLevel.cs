using DG.Tweening;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Game_core.Level
{
    public class BaseLevel : MonoBehaviour
    {
        [SerializeField] private int value;
    
        [SerializeField] private int victoryValue;

        [SerializeField] private GameObject ok;
        
        [SerializeField] private float victoryDelay = 2;

        [HideInInspector] public UnityEvent victoryEvent;
        
        [Inject] private PopupManager popupManager;
        
        private bool isVicory;

        #region Properties

        public virtual int Value
        {
            get => value;
            set
            {
                this.value = value;
                TryLaunchVictory();
            }
        }
        
        public virtual int VictoryValue
        {
            get => victoryValue;
            
            set => victoryValue = value;
        }

        #endregion
    
        #region Methods

        public void TryLaunchVictory()
        {
            if(CheckVictoryConditions()) Victory();
        }

        public virtual bool CheckVictoryConditions()
        {
            if (Value == VictoryValue)
            {
                return true;
            }

            return false;
        }

        public virtual void Victory()
        {
            if (isVicory) return;
            
            victoryEvent?.Invoke();
            isVicory = true;
            ok.gameObject.SetActive(true);

            DOTween.Sequence().AppendInterval(victoryDelay).AppendCallback((() => popupManager.GetPopup("Victory").Show()));
        }

        #endregion
    }
}