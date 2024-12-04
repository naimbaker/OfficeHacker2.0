using UnityEngine;
using System;

public class MeetingArea1 : MonoBehaviour
{
    public static event Action<Vector3> PositionBroadcast;

    void Update()
    {
        if (PasswordPuzzle.isLoggedIn)
        {
            BroadcastPosition();
            PasswordPuzzle.isLoggedIn = false;
            Debug.Log("Come to the meeting.");
        }
    }

    private void BroadcastPosition()
    {
        if (PositionBroadcast != null)
        {
            Debug.Log("Broadcasting position: " + transform.position);
            PositionBroadcast.Invoke(transform.position);
        }
    }
}