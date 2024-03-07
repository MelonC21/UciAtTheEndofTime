using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public FadingScript fadeUIBlack;
    [SerializeField] private GameObject textElements;

    [SerializeField] private AudioSource musicToPlay;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private float currentPitch;
    [SerializeField] private float decreasePitch = 0.15f;
    [SerializeField] private int maxAttempt = 5;

    private bool maxAttemptsReached = false;
    private float newPitch;

    private int currentAttempt;

    private void Start()
    {
        currentAttempt = 1; 
    }

    public void NoButton()
    {
        //Add win?
        Debug.Log("You Win??");
    }

    public void YesButton()
    {
        Debug.Log(currentAttempt);
        if (currentAttempt <= maxAttempt)
        {
            
            currentAttempt += 1;
            newPitch = musicToPlay.pitch -= decreasePitch;
            pitchDown();
        }
        else
        {
            Debug.Log("It's okay to have forgotten");
            //AddLoss
            fadeUIBlack.FadeOut();
            textElements.SetActive(false);
        }
    }


    private void pitchDown()
    {
        StartCoroutine(pitchMusicDown(musicToPlay, musicToPlay.pitch, newPitch, fadeDuration));
    }

    private IEnumerator pitchMusicDown(AudioSource au, float start, float end, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            au.pitch = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }

        au.pitch = end;
    }
}
