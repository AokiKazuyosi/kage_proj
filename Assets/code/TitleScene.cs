using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void OnEasy()
    {
        GameSettings.difficulty = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void OnNormal()
    {
        GameSettings.difficulty = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnHard()
    {
        GameSettings.difficulty = 2;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
