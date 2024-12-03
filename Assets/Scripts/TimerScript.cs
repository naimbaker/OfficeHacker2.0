using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer.text = "00.0";
    }

    public void UpdateTimer(string time) {

        timer.text = time;
    }
}
