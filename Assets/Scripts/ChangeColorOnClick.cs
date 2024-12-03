using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    public Color newColor = Color.red;
    public int stressImpact;
    private bool alreadyClicked = false;
    public Vector3 newScale = new Vector3(2f, 2f, 2f); 
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
        if (alreadyClicked)
        {
            return;
        }

        alreadyClicked = true;

        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = newColor;
        }

        transform.localScale = newScale;
        GlobalValues.stress += stressImpact;

        if (audioSource != null && audioSource.enabled)
        {
            audioSource.Play();
        }
    }
}