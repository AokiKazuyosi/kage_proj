using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleButton : MonoBehaviour
{
    public void OnClickRule()
    {
        SceneManager.LoadScene("RuleScene");
    }
}
