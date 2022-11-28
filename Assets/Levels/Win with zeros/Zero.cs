using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game_core.Level;
using Level;
using UnityEngine;

public class Zero : MonoBehaviour
{
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private Vector2 victoryPos;

    private void Awake()
    {
        baseLevel.victoryEvent.AddListener((() =>
        {
            transform.DOLocalMove(victoryPos, 0.3f);
        }));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            baseLevel.Value--;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            baseLevel.Value++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            baseLevel.Value++;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            baseLevel.Value--;
        }
    }
    
    /*private IEnumerator SetVictoryPos(float delay)
    {
        GetComponent<Drag>().enabled = false;

        Vector2 startPos = transform.localPosition;
        Vector2 endPos = victoryPos;

        float timer = 0;
        float speed = 0;

        while (timer < delay)
        {
            timer += Time.deltaTime;

            speed = timer / delay;

            transform.localPosition = Vector2.Lerp(startPos, endPos, speed);

            yield return null;
        }

        if ((Vector2)transform.localPosition != endPos) transform.localPosition = endPos;
        
        
    }*/
}

