using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaygroundAI : MonoBehaviour
{
    private Vector3 m_destination;
    [SerializeField] private float m_range;

    private NavMeshAgent m_navMeshAgent;
    [SerializeField] private GameObject m_player;

    private void Start()
    {        
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        FindDestination();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, m_player.transform.position);

        if (distanceFromPlayer <= m_range)
        {
            FollowPlayer();
        }

        if (m_navMeshAgent.remainingDistance <= 0.5)
        {
            FindDestination();
        }


    }

    public void FindDestination()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        int index = Random.Range(0, waypoints.Length);

        m_destination = waypoints[index].transform.position;

        m_navMeshAgent.destination = m_destination;
    }

    public void FollowPlayer()
    {
        m_navMeshAgent.destination = m_player.transform.position;
    }
}
