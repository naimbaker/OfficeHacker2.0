using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseClick : MonoBehaviour
{
    public TextMeshPro computerText;
    public int stressImpact;
    public GameObject[] puzzle;
    private bool alreadyClicked = false;
    private AudioSource audioSource;

    public static event System.Action<Vector3> MouseActivated;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found on this GameObject.");
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

        MouseActivated?.Invoke(transform.position);

        alreadyClicked = true;
        PasswordPuzzle.isComputerOn = true;

        computerText.text = "Enter Password";
        GlobalValues.stress += stressImpact;

        if (audioSource != null && audioSource.enabled)
        {
            audioSource.Play();
        }
    }
}