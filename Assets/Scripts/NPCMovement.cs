using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;

    private float timer;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        WanderRandomly();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderInterval && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            WanderRandomly();
            timer = 0;
        }
    }

    void WanderRandomly()
    {
        Vector3 randomDestination = RandomNavMeshPoint(transform.position, wanderRadius);
        agent.SetDestination(randomDestination);
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