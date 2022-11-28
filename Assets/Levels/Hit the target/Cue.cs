using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Cue : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private AudioClip audioClip;

    [Inject] private Audio _audio;

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Animation>().Play("KiyAnim");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (baseLevel.Value == 1)
            {
                _audio.PlaySound(audioClip);
                collision.gameObject.GetComponent<Animation>().Play("BallWinAnim");
                baseLevel.Victory();
            }
            else
            {
                _audio.PlaySound(audioClip);
                collision.gameObject.GetComponent<Animation>().Play("BallAnim");
            }
                
        }
    }
}

