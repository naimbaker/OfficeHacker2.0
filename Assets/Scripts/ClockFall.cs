using UnityEngine;

public class AddRigidbodyOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            Debug.Log("Rigidbody added, you genius!");
        }
    }
}
