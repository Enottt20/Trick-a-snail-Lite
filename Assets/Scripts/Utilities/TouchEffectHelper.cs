using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffectHelper : MonoBehaviour
{
    public GameObject clickPref, parenPref;

    private RectTransform rect;

    private Vector2 fingerDown;
    private Vector2 fingerUp;

    private float SWIPE_THRESHOLD = 50f;

    private void PlayAnim(Vector2 pos)
    {
        Vector2 localPoint = Camera.main.ScreenToWorldPoint(pos);

        var cl = Instantiate(clickPref, parenPref.transform);
        Canvas.ForceUpdateCanvases();
        cl.transform.position = localPoint;
    }

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        
#if UNITY_EDITOR

        if (Input.GetMouseButtonUp(0))
        {
            var touchPos = Input.mousePosition;
            if (IsInRect(rect, touchPos)) PlayAnim(touchPos);
        }
#else
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                fingerDown = touch.position;
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }
        }
#endif
        }

    private float VerticalMove() => Mathf.Abs(fingerDown.y - fingerUp.y);

    private float HorizontalValMove() => Mathf.Abs(fingerDown.x - fingerUp.x);

    private bool IsInRect(RectTransform rectT, Vector2 pos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectT, pos, Camera.main, out localPoint);
        return rectT.rect.Contains(localPoint);
    }

    private void CheckSwipe()
    {
        //Check if Vertical swipe
        if (VerticalMove() > SWIPE_THRESHOLD && VerticalMove() > HorizontalValMove())
        {
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (HorizontalValMove() > SWIPE_THRESHOLD && HorizontalValMove() > VerticalMove())
        {
            fingerUp = fingerDown;
        }
        
        else
        {
            if (IsInRect(rect, fingerDown))
            {
                Vector2 touchPos = fingerDown;
                PlayAnim(touchPos);
            }
        }
    }

}
