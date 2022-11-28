using Game_core.Level;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace Game_core
{
    public class InputValue : MonoBehaviour
    {
        [SerializeField] private BaseLevel baseLevel;
        [SerializeField] private Text valueText;
        [SerializeField] private Button checkButton;

        private void Awake() => checkButton.onClick.AddListener(CheckValue);

        private void CheckValue() => baseLevel.Value = System.Convert.ToInt32(valueText.text);
    }
}
