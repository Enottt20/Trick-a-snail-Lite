using System;
using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using UnityEngine;

public class Chest2 : BaseLevel
{
    [SerializeField] private Chest1 chest1;
    
    private bool canGetValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Value >= 3 && canGetValue)
            {
                var obj = collision.gameObject;
                Value ++;
                obj.GetComponent<Animation>().Play();
                Destroy(obj, 0.33f);
            }
        }
        
        if(collision.gameObject == chest1.gameObject)
        {
            canGetValue = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == chest1.gameObject)
        {
            canGetValue = true;
        }
    }
}
