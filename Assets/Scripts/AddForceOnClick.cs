using UnityEngine;

public class AddForceOnClick : MonoBehaviour
{
    public float forceAmount = 500f; 
    public Vector3 forceDirection = Vector3.up; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on this object.");
        }
    }

    void OnMouseDown()
    {
        if (rb != null)
        {
            
            rb.AddForce(forceDirection.normalized * forceAmount);
        }
    }
}
