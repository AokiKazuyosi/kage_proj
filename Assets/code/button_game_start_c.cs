using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class button_game_start_c : MonoBehaviour, IPointerEnterHandler
{
    public Button m_startBtn;

    public Image buttonImage;
    public TextMeshProUGUI buttonText;

    [Header("SE")]
    public AudioClip hoverSE;   // カーソル音
    public AudioClip clickSE;   // クリック音

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        m_startBtn.onClick.AddListener(osu);
        StartCoroutine(Blink());
    }

    private void OnDestroy()
    {
        m_startBtn.onClick.RemoveListener(osu);
    }

    // クリック時
    void osu()
    {
        StopAllCoroutines();
        SetAlpha(1f);

        audioSource.PlayOneShot(clickSE);

        SceneManager.LoadScene("DifficultyScene");
    }

    // カーソルが乗った瞬間
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSE);
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
