using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    [SerializeField] private float time = 1;

    private void Start() => DestroyDelay();

    private async Task DestroyDelay()
    {
        await Task.Delay(TimeSpan.FromSeconds(time));
        Destroy(gameObject);
    }  
}
