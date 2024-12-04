using UnityEngine;

public class ClickToFall : MonoBehaviour
{
    public int stressImpact;
    public Rigidbody fallingBlockBody;
    private AudioSource audioSource;
    private bool collided = false;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collided == false & collision.gameObject.CompareTag("Boss"))
        {
            GlobalValues.stress += stressImpact;
            collided = true;
        }
    }
}