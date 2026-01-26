using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIHoverEffect : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{
    [Header("Frame (ì_ñ≈Ç≥ÇπÇÈòg)")]
    [SerializeField] Image frameImage;

    [Header("ägëÂê›íË")]
    [SerializeField] float scaleUp = 1.1f;
    [SerializeField] float scaleSpeed = 10f;

    Vector3 defaultScale;
    Coroutine blinkCoroutine;
    bool isHover = false;

    void Start()
    {
        defaultScale = transform.localScale;

        // ògÇç≈èâÇÕï\é¶ÇµÇ»Ç¢
        if (frameImage != null)
            frameImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // ägëÂÅEèkè¨ÇÇ»ÇﬂÇÁÇ©Ç…
        Vector3 targetScale = isHover
            ? defaultScale * scaleUp
            : defaultScale;

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
    }

    // ÉJÅ[É\ÉãÇ™èÊÇ¡ÇΩèuä‘
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;

        // ògï\é¶Å{ì_ñ≈äJén
        if (frameImage != null)
        {
            frameImage.gameObject.SetActive(true);
            blinkCoroutine = StartCoroutine(FrameBlink());
        }
    }

    // ÉJÅ[É\ÉãÇ™ó£ÇÍÇΩèuä‘
    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;

        // ì_ñ≈í‚é~
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }

        // ògÇå≥Ç…ñﬂÇ∑
        if (frameImage != null)
        {
            frameImage.gameObject.SetActive(false);
            SetFrameAlpha(1f);
        }
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
