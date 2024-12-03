using UnityEngine;
using UnityEngine.UI;

public class PaintingClick : MonoBehaviour
{
    public GameObject painting;
    public GameObject paintingBorder;
    public int stressImpact;
    private AudioSource audioSource;

    void Start()
    {
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
        GlobalValues.stress += stressImpact;

        if (audioSource != null && audioSource.enabled)
        {
            audioSource.Play();
            Destroy(painting, audioSource.clip.length);
            Destroy(paintingBorder, audioSource.clip.length);
        }
        else
        {
            Destroy(painting);
            Destroy(paintingBorder);
        }
    }
}
