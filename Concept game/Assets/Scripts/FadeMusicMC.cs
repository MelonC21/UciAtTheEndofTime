using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusicMC : MonoBehaviour
{

    [SerializeField] private AudioSource musicToPlay;

    [SerializeField] private float fadeDuration = 5.0f;
    [SerializeField] private float startVolume = 0f;
    [SerializeField] private float endVolume = 0.35f;

    [SerializeField] private bool fadeIn = false;

    private void Start()
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
        StartCoroutine(FadeMusicSource(musicToPlay, startVolume, endVolume, fadeDuration));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeMusicSource(musicToPlay, endVolume, startVolume, fadeDuration));
    }

    private IEnumerator FadeMusicSource(AudioSource au, float start, float end, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            au.volume = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }

        au.volume = end;
    }
}
