using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 3f;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null)
        {
            audioSource.volume = 0f;
            StartCoroutine(FadeInAudio());
        }
        else
        {
            Debug.LogError("No AudioSource found on the GameObject or assigned.");
        }
    }

    private System.Collections.IEnumerator FadeInAudio()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        audioSource.volume = .5f;
    }
}
