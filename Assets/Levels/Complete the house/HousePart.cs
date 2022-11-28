using System.Collections;
using System.Collections.Generic;
using Game_core;
using Game_core.Level;
using Level;
using UnityEngine;
using DG.Tweening;

public class HousePart : MonoBehaviour
{
    [SerializeField] private BaseLevel baseLevel;
    
    [SerializeField] private Vector2 buildPos;

    [SerializeField] private float buildDelay;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Drag>().enabled = false;
            Build(buildDelay);
            baseLevel.Value++;
        }
    }

    private void Build(float delay)
    {
        transform.DOLocalMove(buildPos, delay);
    }
}
