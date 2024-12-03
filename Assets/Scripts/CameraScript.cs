using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject[] Cameras;
    public DisplayCameraName camDisplay;
    public static string currentCameraName;

    private int currentCamera = 0;
    private int cameraCount;


    void Start() {
        cameraCount = Cameras.Length;
        foreach (GameObject cam in Cameras) {
            cam.SetActive(false);
            cam.GetComponent<AudioListener>().enabled = false;
        }
        Cameras[0].SetActive(true);
        Cameras[0].GetComponent<AudioListener>().enabled = true;
        currentCameraName = Cameras[0].name;
    }

    void Update()
    {
        if (Input.GetKeyDown("1")) {
            CameraDown();
        }

        if (Input.GetKeyDown("2")) {
            CameraUp();
        }
    }

    void CameraDown() {
        int prev = currentCamera;
        currentCamera--;
        currentCamera = HandleEdges(currentCamera);
        SetCamera(currentCamera, prev);
    }

    void CameraUp() {
        int prev = currentCamera;
        currentCamera++;
        currentCamera = HandleEdges(currentCamera);
        SetCamera(currentCamera, prev);
    }

    int HandleEdges(int current) {
        if (current < 0) {
            current = cameraCount - 1;
        } else if (current > cameraCount - 1) {
            current = 0;
        }
        return current;
    }

    void SetCamera(int cam, int prev) {
        Cameras[cam].SetActive(true);
        Cameras[cam].GetComponent<AudioListener>().enabled = true;
        camDisplay.UpdateCameraDisplay(Cameras[cam].name);
        currentCameraName = Cameras[cam].name;
        Canvas mainCanvas = FindObjectOfType<Canvas>();
        mainCanvas.worldCamera = Cameras[cam].GetComponent<Camera>();

        Cameras[prev].SetActive(false);
        Cameras[prev].GetComponent<AudioListener>().enabled = false;

    }
}
