using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGame : MonoBehaviour
{
    private void Start()
    {
        LoadScenes();
    }

    private void LoadScenes()
    {
        if(Datas.Datas.MaxLevel + 1 < SceneManager.sceneCountInBuildSettings-1)
            SceneManager.LoadScene(Datas.Datas.MaxLevel + 1);
        else 
            SceneManager.LoadScene(1);
    }
}