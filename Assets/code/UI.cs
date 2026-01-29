using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIHoverEffect : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler
{
    [Header("Frame (点滅させる枠)")]
    [SerializeField] Image frameImage;

    [Header("拡大設定")]
    [SerializeField] float scaleUp = 1.1f;
    [SerializeField] float scaleSpeed = 10f;

    [Header("効果音")]
    [SerializeField] AudioSource hoverSE;
    [SerializeField] AudioSource clickSE;   // ★追加

    Vector3 defaultScale;
    Coroutine blinkCoroutine;
    bool isHover = false;

    void Start()
    {
        defaultScale = transform.localScale;

        if (frameImage != null)
            frameImage.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 targetScale = isHover
            ? defaultScale * scaleUp
            : defaultScale;

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;

        if (hoverSE != null)
            hoverSE.PlayOneShot(hoverSE.clip);

        if (frameImage != null)
        {
            frameImage.gameObject.SetActive(true);
            blinkCoroutine = StartCoroutine(FrameBlink());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;

        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }

        if (frameImage != null)
        {
            frameImage.gameObject.SetActive(false);
            SetFrameAlpha(1f);
        }
    }

    // ★クリック音
    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSE != null)
            clickSE.PlayOneShot(clickSE.clip);
    }

    IEnumerator FrameBlink()
    {
        while (true)
        {
            yield return FadeFrame(1f, 0.2f, 0.4f);
            yield return FadeFrame(0.2f, 1f, 0.4f);
        }
    }

    IEnumerator FadeFrame(float from, float to, float time)
    {
        float t = 0f;
        Color c = frameImage.color;

        while (t < time)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(from, to, t / time);
            frameImage.color = c;
            yield return null;
        }
    }

    void SetFrameAlpha(float a)
    {
        Color c = frameImage.color;
        c.a = a;
        frameImage.color = c;
    }
}
