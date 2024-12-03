using UnityEngine;

public class ClickToFall : MonoBehaviour
{
    public Rigidbody fallingBlockBody;
    private AudioSource audioSource;

    void Start()
    {
        fallingBlockBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found.");
        }
        else if (!audioSource.enabled)
        {
            audioSource.enabled = true;
        }
    }

    void OnMouseDown()
    {
        fallingBlockBody.useGravity = true;

        if (audioSource != null && audioSource.enabled)
        {
            audioSource.Play();
        }
    }
}