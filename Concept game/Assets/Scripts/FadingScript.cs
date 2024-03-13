using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private float fadeDuration = 5.0f;
    [SerializeField] private int fadeDelay = 0;
    [SerializeField] private float fadeAlpha = 0f;
    [SerializeField] private float startingAlpha = 1f;

    [SerializeField] private bool fadeIn = false;

    private void OnEnable()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }


    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, startingAlpha, fadeAlpha, fadeDuration));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, fadeAlpha, startingAlpha, fadeDuration));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        yield return new WaitForSeconds(fadeDelay);

        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }

        cg.alpha = end;
    }
}
