using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using UnityEngine;
using UnityEngine.EventSystems;

public class Switch : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private SpriteRenderer[] simpleObjects;
    [SerializeField] private SpriteRenderer car;
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;
    [SerializeField] private Color carLightOnColor;
    [SerializeField] private Color carGlowingColor;
    [SerializeField] private Color cameraOffColor;
    private bool lightState = true;
    
    /// <summary>
    /// true - on light;
    /// false - off light
    /// </summary>
    public bool LightState
    {
        get => lightState;
        set => lightState = value;
    }

    private void OnLight()
    {
        foreach (var obj in simpleObjects)
        {
            obj.color = onColor;
        }
        Camera.main.backgroundColor =  onColor;

        car.color = carLightOnColor;
    }

    private void OffLight()
    {
        foreach (var obj in simpleObjects)
        {
            obj.color = offColor;
        }
        
        Camera.main.backgroundColor =  cameraOffColor;

        if (baseLevel.Value == 1)
        {
            car.color = carGlowingColor;   
        }
        else
        {
            car.color = offColor;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //если вкл то делаем выкл и наоборот
        if (LightState)
        {
            LightState = false;
            OffLight();
        }
        else
        {
            LightState = true;
            OnLight();
        }
       
    }
}
