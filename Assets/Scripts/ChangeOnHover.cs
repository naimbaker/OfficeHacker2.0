using UnityEngine;

public class HoverColorChange : MonoBehaviour
{
    public Color hoverColor;
    private Color originalColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    void OnMouseEnter()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = originalColor;
    }
}