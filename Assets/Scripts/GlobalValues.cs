using UnityEngine;
using UnityEngine.UI;

public class GlobalValues : MonoBehaviour
{
    public static int stress;
    public Slider StressSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StressSlider.value = stress;
    }
}
