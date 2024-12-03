using UnityEngine;

public class ChangeTargetMaterial : MonoBehaviour
{
    public GameObject targetObject;
    public Material newMaterial;
    public int stressImpact;
    public int targetMaterialIndex;
    public bool isStressful;


    void OnMouseDown() {
        if (targetObject != null) {
            Renderer targetRenderer = targetObject.GetComponent<Renderer>();
            Material[] tmpMatList = targetRenderer.materials;
            tmpMatList[1] = newMaterial;
            targetRenderer.materials = tmpMatList;

            GlobalValues.stress += stressImpact;


        }

        targetObject = null;

        
    }
}
