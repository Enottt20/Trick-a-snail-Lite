using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game_core;
using Game_core.Level;
using Level;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private Vector2 maxScale;
    [SerializeField] private Vector2 victoryPos;
    private Vector2 f0start, f1start;

    private void Awake()
    {
        baseLevel.victoryEvent.AddListener((() =>
        {
            GetComponent<Drag>().enabled = false;
            transform.DOLocalMove(victoryPos, 0.3f);
        }));
    }

    private void Update()
    {
        if(Input.touchCount == 2)
        {
            Zoom();
        }
        
        if (Input.touchCount < 2)
        {
            f0start = Vector2.zero;
            f1start = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(baseLevel.Value != 1) return; 
        
        if (other.gameObject.CompareTag("Finish"))
        {
            baseLevel.Victory();
        }
    }

    private void Zoom()
    {

        if (f0start == Vector2.zero && f1start == Vector2.zero)
        {
            f0start = Input.GetTouch(0).position;
            f1start = Input.GetTouch(1).position;
        }
        
        Vector2 f0position = Input.GetTouch(0).position;
        Vector2 f1position = Input.GetTouch(1).position;

        var sensitivity = Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position);
        
        if (sensitivity < -200)
        {
            baseLevel.Value = 1;
            transform.DOScale(maxScale, 0.3f);
        }

    }
}