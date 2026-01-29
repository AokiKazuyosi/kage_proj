using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // š‚±‚êd—v

public class RuleScene : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
