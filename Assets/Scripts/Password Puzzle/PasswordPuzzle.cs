using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class PasswordPuzzle : MonoBehaviour
{
    public static string userInput;
    public static bool isComputerOn;
    public string password;
    public TextMeshPro passwordDisplay;
    public TextMeshPro computerDisplay;
    public GameObject strangePhoto;
    public GameObject meetingTV;
    private int stressImpact;
    public static bool isLoggedIn;

    void Start()
    {
        userInput = "";
        isComputerOn = false;
        isLoggedIn = false;
        stressImpact = 20;
        strangePhoto.SetActive(false);
        meetingTV.SetActive(false);
    }

    void Update()
    {
        if (CameraScript.currentCameraName == "Hallway Computer" && isComputerOn && !isLoggedIn) {
            passwordDisplay.text = userInput;
            if (Input.inputString.Length > 0) {
                if (Input.GetKeyDown(KeyCode.Backspace)) {
                    if (userInput.Length > 0) {
                        userInput = BackspaceString(userInput);
                    }
                } else if (Input.GetKeyDown(KeyCode.Return)) {
                    if (isCorrectPassword()) {
                        computerDisplay.text = "Login Successful";
                        GlobalValues.stress += stressImpact;
                        isLoggedIn = true;
                        Invoke("changeSecret", 2f);
                    } else {
                        computerDisplay.text = "Try Again";
                    }
                    userInput = "";
                } else {
                    userInput += Input.inputString;
                }
            }
        } else {
            return;
        }
        

    }

    bool isCorrectPassword() {
        string sortedInput = SortInput(userInput);
        return sortedInput == password;
    }

    string SortInput(string str) {
        char[] inputChars = str.ToCharArray();
        Array.Sort(inputChars);
        return new string(inputChars);
    }

    string BackspaceString(string str) {
        return str.Substring(0, str.Length - 1);
        
    }
    void changeSecret() {
        computerDisplay.text = "You Found the Boss' Secret.";
        strangePhoto.SetActive(true);
        meetingTV.SetActive(true);
    }


}
