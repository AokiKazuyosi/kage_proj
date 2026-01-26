using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class button_game_start_c : MonoBehaviour
{
    public Button m_startBtn;


    public Image buttonImage;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        m_startBtn.onClick.AddListener(osu);

        //GetComponent<Button>().onClick.AddListener(osu);


        StartCoroutine(Blink());
    }

    private void OnDestroy()
    {

        m_startBtn.onClick.RemoveListener(osu);

    }

    void osu()
    {
        StopAllCoroutines();
        SetAlpha(1f); // âüÇµÇΩèuä‘Ç…ï\é¶å≈íË
        SceneManager.LoadScene("DifficultyScene");
    }

    IEnumerator Blink()
    {
        float t = 0f;

        while (true)
        {
            t += Time.deltaTime * 2f;
            float alpha = Mathf.Abs(Mathf.Sin(t));
            SetAlpha(alpha);
            yield return null;
        }
    }

    void SetAlpha(float a)
    {
        Color c;

        c = buttonImage.color;
        c.a = a;
        buttonImage.color = c;

        c = buttonText.color;
        c.a = a;
        buttonText.color = c;
    }
}
