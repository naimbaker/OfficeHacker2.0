using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CylinderMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 1f;
    public GameObject exclamationPoint;

    private bool meetingTime = false;
    private Transform[] targetAreas;
    private float timer;
    private int currentTargetIndex = 0;

    private bool runToRadio = false; // Tracks if the boss is chasing the radio
    private GameObject radioObject; // Tracks the radio object

    private bool runToMouse = false; // Tracks if the boss is chasing the mouse
    private GameObject mouseObject; // Tracks the mouse object

    private bool runToMeeting = false; // Tracks if the boss is headed to the meeting
    private GameObject meetingObject; // Tracks the meeting object

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        TargetAreaManager manager = FindObjectOfType<TargetAreaManager>();
        targetAreas = manager.GetTargetAreas();
        exclamationPoint.SetActive(false);

        // Subscribe to the radio and mouse event
        RadioClick.OnRadioActivated += MoveToRadio;
        MouseClick.MouseActivated += MoveToMouse;

        MeetingArea1.MeetingCall += MoveToMeeting;


    }

    void Update()
    {
        if (meetingTime == true)
        {
            return;
        }
        
        if (runToRadio)
        {
            // Check if boss has reached the radio
            if (!agent.pathPending && agent.remainingDistance <= (agent.stoppingDistance + 0.02))
            {
                TurnOffRadio();
                exclamationPoint.SetActive(false);
                runToRadio = false; // Resume wandering behavior
            }
            return;
        }

        if (runToMouse)
        {
            
            // Check if boss has reached the mouse
            if (!agent.pathPending && agent.remainingDistance <= (agent.stoppingDistance + 0.02))
            {
                if(PasswordPuzzle.isLoggedIn == false){
                    SceneManager.LoadScene(3);
                }

                exclamationPoint.SetActive(false);
                runToMouse = false; // Resume wandering behavior
            }
            return;
        }

        // Regular wandering behavior
        timer += Time.deltaTime;

        if (timer >= wanderInterval)
        {
            if (Random.value < 0.01f && targetAreas.Length > 0)
            {
                MoveToNextTarget();
            }
            else
            {
                WanderRandomly();
            }
            timer = 0;
        }
    }



    void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        RadioClick.OnRadioActivated -= MoveToRadio;
        MouseClick.MouseActivated -= MoveToMouse;

        MeetingArea1.MeetingCall -= MoveToMeeting;
    }

    void WanderRandomly()
    {
        Vector3 newPos = RandomNavMeshPoint(transform.position, wanderRadius);
        agent.SetDestination(newPos);
    }

    void MoveToNextTarget()
    {
        Vector3 targetPosition = targetAreas[currentTargetIndex].position;
        agent.SetDestination(targetPosition);

        currentTargetIndex = (currentTargetIndex + 1) % targetAreas.Length;
    }

    void MoveToRadio(Vector3 radioPosition)
    {
        // Make sure the radioObject is found when needed
        radioObject = FindObjectOfType<RadioClick>()?.gameObject;

        if (radioObject != null)
        {
            // Set chasing state and move toward the radio
            runToRadio = true;
            agent.SetDestination(radioPosition);
            exclamationPoint.SetActive(true);
            Debug.Log("Boss is moving to the radio at " + radioPosition);
        }
        else
        {
            Debug.LogError("Radio object is not assigned!");
        }
    }

    void TurnOffRadio()
    {
        if (radioObject != null)
        {
            RadioClick radioScript = radioObject.GetComponent<RadioClick>();
            if (radioScript != null)
            {
                radioScript.TurnOff();
                Debug.Log("Boss turned off the radio.");
            }
        }
    }

    void MoveToMouse(Vector3 mousePosition)
    {
        // Make sure the mouseObject is found when needed
        mouseObject = FindObjectOfType<MouseClick>()?.gameObject;
        meetingObject = FindObjectOfType<MeetingArea1>()?.gameObject; 

        if (mouseObject != null)
        {
            // Set chasing state and move toward the mouse
            runToMouse = true;
            agent.SetDestination(mousePosition);
            exclamationPoint.SetActive(true);
            Debug.Log("Boss is moving to the Mouse at " + mousePosition);
        }
        else
        {
            Debug.LogError("Mouse object is not assigned!");
        }
        if (PasswordPuzzle.isLoggedIn)
        {
            if (meetingObject != null)
            {
                MoveToMeeting(meetingObject.transform.position);
            }
            else
            {
                Debug.LogError("Meeting object is not assigned!");
            }
        }
    }

    void MoveToMeeting(Vector3 meetingPosition)
    {
        meetingObject = FindObjectOfType<MeetingArea1>()?.gameObject;

        if (meetingObject != null)
        {
            runToMeeting = true;
            agent.SetDestination(meetingPosition);
            exclamationPoint.SetActive(false);
            Debug.Log("Boss is moving to the meeting at " + meetingPosition);
        }
        else
        {
            Debug.LogError("Meeting object is not assigned!");
        }

        meetingTime = true;
    }

    Vector3 RandomNavMeshPoint(Vector3 origin, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, 1))
        {
            return hit.position;
        }
        return origin;
    }
}