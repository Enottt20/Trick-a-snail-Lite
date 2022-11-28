using System;
using System.Collections;
using System.Collections.Generic;
using Game_core;
using UnityEngine;

public class Chest1 : MonoBehaviour
{
    [SerializeField] private Chest2 chest2;
    private Drag drag;

    private void Start()
    {
        drag = GetComponent<Drag>();
        drag.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(chest2.Value < 3)
            {
                var obj = collision.gameObject;
                chest2.Value ++;
                obj.GetComponent<Animation>().Play();
                Destroy(obj, 0.33f);
            }

            if (chest2.Value == 3)
            {
                drag.enabled = true;
            }
        }
    }
}

