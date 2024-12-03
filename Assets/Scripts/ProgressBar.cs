using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public float timeLimit;
    public TimerScript timer;
    public int winThreshold;
    private float timeElapsed = 0;
    private float timeRemain;
    private float deltaTimeSnapshot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeRemain = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTimeSnapshot = Time.deltaTime;
        timeElapsed += deltaTimeSnapshot;
        timeRemain -= deltaTimeSnapshot;

        timer.UpdateTimer(timeRemain.ToString("F1"));
        if (timeElapsed >= timeLimit) {
            SceneManager.LoadScene(3);
        }

        if (GlobalValues.stress >= winThreshold) {
            SceneManager.LoadScene(2);
        }
    }
}
