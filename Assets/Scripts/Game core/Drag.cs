using UnityEngine;
using UnityEngine.EventSystems;

namespace Game_core
{
    public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool isTouch;

        public void OnPointerDown(PointerEventData eventData) => isTouch = true;
    
        public void OnPointerUp(PointerEventData eventData) => isTouch = false;

        private void Update()
        {
            Vector2 touchPos = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
        
            //Без проверки на тач все обьекты типа Drag будут следовать за курсором постоянно
            if (isTouch)
            {
                transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(touchPos), Time.deltaTime * 30);
            }
        }
  
    }
}