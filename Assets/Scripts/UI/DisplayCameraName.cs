using UnityEngine;
using TMPro;

public class DisplayCameraName : MonoBehaviour
{
    public TextMeshProUGUI nameDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameDisplay.text = "MainOffice1";
    }

    public void UpdateCameraDisplay(string name) {
        nameDisplay.text = name;
    }
}
