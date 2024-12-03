using UnityEngine;

public class KeyboardMaterial : MonoBehaviour
{
    public GameObject targetObject;
    public Material newMaterial;
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
        if (targetObject != null)
        {
            Renderer targetRenderer = targetObject.GetComponent<Renderer>();

            if (targetRenderer != null && newMaterial != null)
            {
                if (targetRenderer.materials.Length > 1)
                {
                    Material[] materials = targetRenderer.materials;

                    materials[1] = newMaterial;

                    targetRenderer.materials = materials;
                }
            }

            GlobalValues.stress += stressImpact;

            if (audioSource != null && audioSource.enabled)
            {
                audioSource.Play();
            }
        }

        targetObject = null;
    }
}