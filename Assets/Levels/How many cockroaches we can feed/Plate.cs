using System;
using System.Collections;
using System.Collections.Generic;
using Game_core;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            GetComponent<Drag>().enabled = false;
            anim.Play("Cockroaches");
        }
    }
}
