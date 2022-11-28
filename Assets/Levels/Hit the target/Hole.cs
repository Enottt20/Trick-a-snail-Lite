using System.Collections;
using System.Collections.Generic;
using Game_core.Level;
using Level;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Vector2 f0start, f1start;
    [SerializeField] private BaseLevel baseLevel;
    [SerializeField] private GameObject bigHole;
    
    
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Zoom();
        }

        if (Input.touchCount < 2)
        {
            f0start = Vector2.zero;
            f1start = Vector2.zero;
        }

    }
    void Zoom()
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
            baseLevel.Value=1;
            bigHole.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
