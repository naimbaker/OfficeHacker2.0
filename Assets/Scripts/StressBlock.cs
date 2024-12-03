using UnityEngine;
using UnityEngine.UI;

public class StressBlock : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boss")) {
            GlobalValues.stress += 5;
            Destroy(gameObject);
        }
    }
}
