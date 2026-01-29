using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyUI : MonoBehaviour
{
    public void Easy()
    {
        GameData.difficulty = GameData.Difficulty.Easy;
        SceneManager.LoadScene("GameScene");
    }

    public void Normal()
    {
        GameData.difficulty = GameData.Difficulty.Normal;
        SceneManager.LoadScene("GameScene");
    }

    public void Hard()
    {
        GameData.difficulty = GameData.Difficulty.Hard;
        SceneManager.LoadScene("GameScene");
    }
}
