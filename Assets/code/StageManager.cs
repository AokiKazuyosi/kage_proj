using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Correct_Angle angleChecker;
    public Correct_Angle easy;
    public Correct_Angle normal;
    public Correct_Angle hard;
    public WASD playerController;
    public float clearDelay = 1.5f;

    bool cleared = false;

    void Start()
    {
        SetupByDifficulty();
    }

    void Update()
    {
        if (cleared) return;
        if (angleChecker == null || playerController == null) return;

        if (angleChecker.isSnapped)
        {
            cleared = true;
            //ëÄçÏí‚é~
            playerController.enabled = false;
            //É^ÉCÉgÉãÇ…ñﬂÇÈ
            Invoke(nameof(ReturnToTitle), clearDelay);
        }
    }

    void SetupByDifficulty()
    {
        switch(GameSettings.difficulty)
        {
            case 0: //Easy
                angleChecker.targetX = 30f;
                angleChecker.targetY = 30f;
                break;

            case 1: //Normal
                angleChecker.targetX = 60f;
                angleChecker.targetY = 90f;
                break;

            case 2:
                angleChecker.targetX = 120f;
                angleChecker.targetY = 135f;
                break;
        }
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
