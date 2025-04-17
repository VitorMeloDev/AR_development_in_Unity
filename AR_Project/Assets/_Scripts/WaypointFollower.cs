using UnityEngine;
using System.Collections.Generic;

public class WaypointFollower : MonoBehaviour
{
    [Header("Listas de Waypoints")]
    public List<Transform> waypointsA;
    public List<Transform> waypointsB;

    [Header("Configurações")]
    public float speed = 2f;
    public float distanceThreshold = 0.1f;

    private int currentWaypointIndex = 0;
    private bool usingFirstList = true;

    private List<Transform> currentWaypoints;

    void Start()
    {
        currentWaypoints = waypointsA;
    }

    void Update()
    {
        if (currentWaypoints.Count == 0) return;

        Transform targetWaypoint = currentWaypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;

        // Move o objeto em direção ao waypoint
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Verifica se chegou no waypoint
        if (direction.magnitude <= distanceThreshold)
        {
            currentWaypointIndex++;

            // Se chegou no final da lista atual
            if (currentWaypointIndex >= currentWaypoints.Count)
            {
                // Troca de lista
                usingFirstList = !usingFirstList;
                currentWaypoints = usingFirstList ? waypointsA : waypointsB;
                currentWaypointIndex = 0;
            }
        }
    }
}
