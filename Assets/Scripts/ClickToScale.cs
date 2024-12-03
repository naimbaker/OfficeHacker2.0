using UnityEngine;

public class ClickToScale : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2, 2, 2); // Scale to change to on click
    public float scaleSpeed = 2f; // Speed of the scaling effect
    private Vector3 originalScale; // Original scale to reset to
    private bool isScalingUp = false;
    private bool isScalingDown = false;

    void Start()
    {
        // Record the original scale
        originalScale = transform.localScale;
    }

    void OnMouseDown()
    {
        // Check if we should start scaling up
        if (transform.localScale == originalScale)
        {
            isScalingUp = true;
            isScalingDown = false;
        }
        else
        {
            isScalingDown = true;
            isScalingUp = false;
        }
    }

    void Update()
    {
        // Handle scaling up
        if (isScalingUp)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

            // Stop scaling when target scale is reached
            if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
            {
                transform.localScale = targetScale;
                isScalingUp = false;
            }
        }

        // Handle scaling down
        if (isScalingDown)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);

            // Stop scaling when original scale is reached
            if (Vector3.Distance(transform.localScale, originalScale) < 0.01f)
            {
                transform.localScale = originalScale;
                isScalingDown = false;
            }
        }
    }
}
