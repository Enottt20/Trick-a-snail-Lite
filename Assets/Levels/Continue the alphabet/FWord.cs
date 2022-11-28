using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game_core;
using Game_core.Level;
using Level;

public class FWord : MonoBehaviour
{
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private Vector2 victoryPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            GetComponent<Drag>().enabled = false;
            transform.DOLocalMove(victoryPos, 0.3f);
            baseLevel.Victory();
        }
    }
}
