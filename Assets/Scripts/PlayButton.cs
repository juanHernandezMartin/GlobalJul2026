using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public string playSceneName;

    public void GoToPlayScene()
    {
        SceneManager.LoadScene(playSceneName);
    }
}
