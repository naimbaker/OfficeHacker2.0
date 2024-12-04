using UnityEngine;

public class ChangeTargetMaterial : MonoBehaviour
{
    public GameObject targetObject;
    public Material newMaterial;
    public int stressImpact;
    public int targetMaterialIndex;
    public bool isTV;



    void OnMouseDown() {
        if (isTV) {
            if (PasswordPuzzle.isLoggedIn) {
                changeMat();
                targetObject = null;
            } else {
                return;
            }
        } else {
            if (targetObject != null) {
                changeMat();
            }
            targetObject = null;
        } 
    }

    private void changeMat() {
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        Material[] tmpMatList = targetRenderer.materials;
        tmpMatList[1] = newMaterial;
        targetRenderer.materials = tmpMatList;
        GlobalValues.stress += stressImpact;
    }
}
