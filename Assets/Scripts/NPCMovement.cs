using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;

    private float timer;
    private bool isAtMeeting = false;
    private bool runToMeeting = false; // Tracks if the boss is headed to the meeting
    private GameObject meetingObject; // Tracks the meeting object

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        WanderRandomly();

        MeetingArea1.MeetingCall += MoveToMeeting;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= wanderInterval && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            WanderRandomly();
            timer = 0;
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

    void OnDestroy()
    {
        MeetingArea1.MeetingCall -= MoveToMeeting;
    }

    void WanderRandomly()
    {
        Vector3 randomDestination = RandomNavMeshPoint(transform.position, wanderRadius);
        agent.SetDestination(randomDestination);
    }

    void MoveToMeeting(Vector3 meetingPosition)
    {
        meetingObject = FindObjectOfType<MeetingArea1>()?.gameObject;

        if (meetingObject != null)
        {
            runToMeeting = true;
            agent.SetDestination(meetingPosition);
            Debug.Log("Boss is moving to the meeting at " + meetingPosition);
        }
        else
        {
            Debug.LogError("Meeting object is not assigned!");
        }
    }

    Vector3 RandomNavMeshPoint(Vector3 origin, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return origin;
    }
}