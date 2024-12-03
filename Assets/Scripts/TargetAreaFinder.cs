using UnityEngine;

public class TargetAreaManager : MonoBehaviour
{
    private Transform[] targetAreas;
    void Start()
    {
        GameObject[] areaObjects = GameObject.FindGameObjectsWithTag("Target Area");
        targetAreas = new Transform[areaObjects.Length];

        for (int i = 0; i < areaObjects.Length; i++)
        {
            targetAreas[i] = areaObjects[i].transform;
        }
    }

    public Transform[] GetTargetAreas()
    {
        return targetAreas;
    }
}