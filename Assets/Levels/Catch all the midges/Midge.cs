using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using Managers;
using UnityEngine;
using Zenject;

public class Midge : MonoBehaviour
{
    [SerializeField] private BaseLevel level;
    [SerializeField] private AudioClip dieSound;

    [Inject] private Audio _audio;

    public void OnPress()
    {
        _audio.PlaySound(dieSound);
        level.Value++;
        Destroy(gameObject);
    }
}
