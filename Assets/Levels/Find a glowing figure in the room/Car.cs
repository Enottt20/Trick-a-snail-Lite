using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using UnityEngine;
using UnityEngine.EventSystems;

public class Car : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private Switch _switch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            baseLevel.Value++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            baseLevel.Value--;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_switch.LightState && baseLevel.Value == 1)
        {
            baseLevel.Victory();
        }
    }
}