using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPathing : MonoBehaviour
{
    [SerializeField] GameObject pathPrefab;

    List<Transform> waypoints;
    int waypointsIndex = 0;
    float moveSpeed = 5f;

    private void Start()
    {
        waypoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefab.transform)
        {
            waypoints.Add(waypoint);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(waypointsIndex <= waypoints.Count - 1)
        {
            Vector2 targetPosition = waypoints[waypointsIndex].transform.position;
            float movementPerFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementPerFrame);
            if((Vector2)transform.position == targetPosition)
            {
                waypointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
