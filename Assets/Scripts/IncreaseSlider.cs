using UnityEngine;
using UnityEngine.UI;

public class IncreaseSlider : MonoBehaviour
{
    public Slider stressProgress;
    public int stressImpact;

    void OnMouseDown() {
        stressProgress.value += stressImpact;
    }
}
