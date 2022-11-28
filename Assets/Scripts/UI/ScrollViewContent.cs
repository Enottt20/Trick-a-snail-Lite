using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ScrollViewContent : MonoBehaviour
    {
        [SerializeField] private LevelButton[] levels;
    
        private void Start()
        {
            transform.localPosition = new Vector2(0, -levels[SceneManager.GetActiveScene().buildIndex - 1].transform.localPosition.y - 600);
            levels[SceneManager.GetActiveScene().buildIndex - 1].PinkFrameInput(true);
        }
    }
}
