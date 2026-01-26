using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Correct_Angle : MonoBehaviour
{
    public float rotateSpeed = 10f;
    public bool isCorrect = false;

    public StageManager stageManager;

    float currentX;
    float currentY;

    [Header("Target Rotation (degrees)")]
    public float targetX; //Xの正解度
    public float targetY; //Yの正解度

    [Header("Match Settings")]
    public float maxAngleError = 90f;

    [Header("Snap Settings")]
    public float snapThreshold = 99f;
    public float snapSpeed = 360f;

    [Header("UI")]
    public Slider matchSlider;

    [Header("UI Color")]
    public Image fillImage;
    public Color normalColor = Color.white;
    public Color clearColor = Color.green;
    public float clearThreshold = 95f;
    void Start()
    {
        currentX = 0f;
        currentY = 0f;
    }

    void Update()
    {
        float percent = CalculateMatchPercent();

        //スナップ処理
        if (percent >= snapThreshold)
        {
            SnapToTaraget();
        }
        else
        {
            Rotate();
        }
        UpdateUI(percent);
    }

    void Rotate()
    {
        if (Keyboard.current == null) return;
         
        if (Keyboard.current.wKey.isPressed) currentX += rotateSpeed * Time.deltaTime;
        if (Keyboard.current.sKey.isPressed) currentX -= rotateSpeed * Time.deltaTime;
        if (Keyboard.current.aKey.isPressed) currentY += rotateSpeed * Time.deltaTime;
        if (Keyboard.current.dKey.isPressed) currentY -= rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(currentX, currentY, 0f);
    }


    float CalculateMatchPercent()
    {
        float xDiff = Mathf.Abs(Mathf.DeltaAngle(currentX, targetX));
        float yDiff = Mathf.Abs(Mathf.DeltaAngle(currentY, targetY));

        float xScore = Mathf.Clamp01(1f - xDiff / maxAngleError) * 0.5f;
        float yScore = Mathf.Clamp01(1f - yDiff / maxAngleError) * 0.5f;

        return (xScore + yScore) * 100f;
    }

    void UpdateUI(float percent)
    {
        if (matchSlider!=null)
        {
            matchSlider.value = percent;   
        }

        if(fillImage != null)
        {
            fillImage.color = (percent >= clearThreshold) ? clearColor : normalColor;
        }
    }

    void SnapToTaraget()
    {
        currentX = Mathf.MoveTowardsAngle(
        currentX, targetX, snapSpeed * Time.deltaTime);

        currentY = Mathf.MoveTowardsAngle(
            currentY, targetY, snapSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(currentX, currentY, 0f);

        if (Mathf.Abs(Mathf.DeltaAngle(currentX, targetX)) < 0.1f &&
            Mathf.Abs(Mathf.DeltaAngle(currentY, targetY)) < 0.1f)
        {
            isCorrect = true;
        }
    }

    public bool IsCleared()
    {
        float percent = CalculateMatchPercent();
        return percent >= clearThreshold;
    }
}
