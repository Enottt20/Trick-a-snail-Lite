using System;
using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoe : MonoBehaviour
{
    [SerializeField] private BaseLevel level;

    /*private void Update()
    {
        //В эдиторе не работает из за Input.GetTouch
        if (Input.touchCount > 0)
        {
            //Если тянем вниз то ботинок снимается
            if (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y < -1.5f)
            {
                Vector2 newPos = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
                transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime * 20);
            }   
        }

    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        level.Value = 1;
    }
}
