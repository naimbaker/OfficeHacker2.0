using UnityEngine;
using System;

public class MeetingArea1 : MonoBehaviour
{
    public static event Action<Vector3> MeetingCall;

    void Update()
    {
        if (PasswordPuzzle.isLoggedIn)
        {
            PasswordPuzzle.isLoggedIn = false;

            Debug.Log($"Broadcasting position: {transform.position}");
            MeetingCall?.Invoke(transform.position);
        }
    }
}