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
        if (easy == null || normal == null || hard == null)
        {
            Debug.LogError("Stage objects are not assigned");
            return;
        }

        easy.SetActive(false);
        normal.SetActive(false);
        hard.SetActive(false);

        switch (GameData.difficulty)
        {
            case GameData.Difficulty.Easy:
                ActivateStage(easy, easyCamara, -30f, -30f);
                break;

            case GameData.Difficulty.Normal:
                ActivateStage(normal, normalCamera, -120f, -60f);
                break;

            case GameData.Difficulty.Hard:
                ActivateStage(hard, hardCamera, -120f, -120f);
                break;
        }
    }

    void ActivateStage(GameObject stage, Transform cameraPoint, float initX, float initY)
    {
        // ステージを有効化
        stage.SetActive(true);

        // 非アクティブも含めて Correct_Angle を取得
        Correct_Angle angle =
            stage.GetComponentInChildren<Correct_Angle>(true);

        if (angle == null)
        {
            Debug.LogError(stage.name + " に Correct_Angle が見つかりません");
            return;
        }

        // 初期回転を設定（← initialized = true になる）
        angle.SetInitialRotation(initX, initY);
        currentAngle = angle;

        // カメラ移動
        MoveCamera(cameraPoint);
    }

    void MoveCamera(Transform point)
    {
        if (mainCamera == null || point == null) return;

        mainCamera.transform.position = point.position;
        mainCamera.transform.rotation = point.rotation;
    }

    void Update()
    {
        if (cleared) return;

        if (currentAngle != null && currentAngle.isCorrect) 
        {
            cleared = true;
            //操作停止
            playerController.enabled = false;
            //タイトルに戻る
            Invoke(nameof(ReturnToTitle), clearDelay);
        }
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("clearScene");
    }
}
