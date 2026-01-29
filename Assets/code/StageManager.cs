using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    //public Correct_Angle angleChecker;

    [Header("Stages")]
    public GameObject easy;
    public GameObject normal;
    public GameObject hard;

    [Header("Player")]
    public WASD playerController;

    [Header("Camera")]
    public Camera mainCamera;

    public Transform easyCamara;
    public Transform normalCamera;
    public Transform hardCamera;

    public float clearDelay = 1.5f;
    bool cleared = false;

    Correct_Angle currentAngle;

    void Start()
    {
        //Debug.Log("Difficulty = " + GameData.difficulty);

        easy.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(false);

        switch(GameData.difficulty)
        {
            case GameData.Difficulty.Easy:
                easy.SetActive(true);
                currentAngle = easy.GetComponentInChildren<Correct_Angle>();
                currentAngle.SetInitialRotation(-30f, -30f);
                MoveCamera(easyCamara);
                break;

            case GameData.Difficulty.Normal:
                normal.SetActive(true);
                currentAngle = normal.GetComponentInChildren<Correct_Angle>();
                currentAngle.SetInitialRotation(-120f, -60f);
                MoveCamera(normalCamera);
                break;

            case GameData.Difficulty.Hard:
                hard.SetActive(true);
                currentAngle = hard.GetComponentInChildren<Correct_Angle>();
                currentAngle.SetInitialRotation(-90f, -120f);
                MoveCamera(hardCamera);
                break;
        }
    }

    void MoveCamera(Transform point)
    {
        if (mainCamera == null || point == null) return;

        mainCamera.transform.position = point.position;
        mainCamera.transform.rotation = point.rotation;
    }

    void Update()
    {
        Debug.Log("CurrentAngle = " + currentAngle.gameObject.name);

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
