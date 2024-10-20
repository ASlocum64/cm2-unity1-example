using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float speed = 5f;      // Speed of the movement
    public float reachThreshold = 0.1f; // Threshold to determine if the waypoint is reached

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Check if there are waypoints defined
        if (waypoints.Length == 0) return;

        // Move towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the GameObject is close enough to the waypoint to consider it reached
        if (direction.magnitude <= reachThreshold)
        {
            // Move to the next waypoint, looping if needed
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
