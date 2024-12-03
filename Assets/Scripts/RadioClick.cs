using UnityEngine;

public class RadioClick : MonoBehaviour
{
    private AudioSource audioSource;

    public static event System.Action<Vector3> OnRadioActivated;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            OnRadioActivated?.Invoke(transform.position);
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void TurnOff()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Radio turned off by boss.");
        }
    }
}