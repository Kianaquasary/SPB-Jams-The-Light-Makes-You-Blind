using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene() 
        => SceneManager.LoadScene(1);

    public void ExitGame()
        =>Application.Quit();
}
