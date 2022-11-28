using System;
using System.Collections.Generic;
using UI.Popup;
using UnityEngine;

namespace Managers
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private List<Popup> popupLists;

        public BasePopup GetPopup(string popupName, int popupListId = 0)
        {
            if (popupListId > popupLists.Count)
            {
                Debug.LogError("Кол-во списков " + popupLists.Count + "Вы указали " + popupListId);
                return null;
            }
            
            foreach (Popup popup in popupLists)
            {
                if (popupName == popup.popupName)
                {
                    return popup.popup;
                }
            }
            
            Debug.LogError("Попап " + popupName +" не найден");
            return null;
        }

        [Serializable]
        public class Popup
        {
            public string popupName;
            public BasePopup popup;
        }
    }
}