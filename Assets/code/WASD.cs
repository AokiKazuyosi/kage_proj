using UnityEngine;
using UnityEngine.InputSystem;

public class WASD : MonoBehaviour
{
    public float rotateSpeed = 45f;

    //float currentX;
    //float currentY;

    //void Start()
    //{
    //    Vector3 euler = transform.eulerAngles;
    //    currentX = euler.x;
    //    currentY = euler.y;
    //}

    //void Update()
    //{
    //    Rotate();
    //}

    //void Rotate()
    //{
    //    if (Keyboard.current == null) return;

    //    if (Keyboard.current.wKey.isPressed) currentX -= rotateSpeed * Time.deltaTime;
    //    if (Keyboard.current.sKey.isPressed) currentX += rotateSpeed * Time.deltaTime;
    //    if (Keyboard.current.aKey.isPressed) currentY -= rotateSpeed * Time.deltaTime;
    //    if (Keyboard.current.dKey.isPressed) currentY += rotateSpeed * Time.deltaTime;

    //    transform.rotation = Quaternion.Euler(currentX, currentY, 0f);
    //}

    //// Åö Correct_Angle Ç©ÇÁåƒÇŒÇÍÇÈ
    //public void SetRotation(float x, float y)
    //{
    //    currentX = x;
    //    currentY = y;
    //    transform.rotation = Quaternion.Euler(currentX, currentY, 0f);
    //}

    public float inputX;
    public float inputY;

    void Update()
    {
        inputX = 0f;
        inputY = 0f;

        if (Keyboard.current == null) return;

        if (Keyboard.current.wKey.isPressed) inputX += rotateSpeed * Time.deltaTime;
        if (Keyboard.current.sKey.isPressed) inputX -= rotateSpeed * Time.deltaTime;
        if (Keyboard.current.aKey.isPressed) inputY += rotateSpeed * Time.deltaTime;
        if (Keyboard.current.dKey.isPressed) inputY -= rotateSpeed * Time.deltaTime;
    }
}
