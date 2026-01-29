using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Correct_Angle angleChecker;

    [Header("Stages")]
    public GameObject easy;
    public GameObject normal;
    public GameObject hard;

    [Header("Player")]
    public WASD playerController;

    public float clearDelay = 1.5f;
    bool cleared = false;

    Correct_Angle currentAngle;

    void Start()
    {
        easy.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(false);

        switch(GameSettings.difficulty)
        {
            case 0:
                easy.SetActive(true);
                currentAngle = easy.GetComponentInChildren<Correct_Angle>();
                break;

            case 1:
                normal.SetActive(true);
                currentAngle = normal.GetComponentInChildren<Correct_Angle>();
                break;

            case 2:
                hard.SetActive(true);
                currentAngle = hard.GetComponentInChildren<Correct_Angle>();
                break;
        }
    }

    void Update()
    {
        if (cleared) return;

        if (currentAngle != null && currentAngle.isCorrect) 
        {
            cleared = true;
            //ëÄçÏí‚é~
            playerController.enabled = false;
            //É^ÉCÉgÉãÇ…ñﬂÇÈ
            Invoke(nameof(ReturnToTitle), clearDelay);
        }
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
