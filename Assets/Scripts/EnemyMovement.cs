using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    [SerializeField] float movementPerFrame = 0.5f;
    [SerializeField] float waypointDwellTime = 1f;

    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint Waypoint in path)
        {
            yield return StartCoroutine(MoveTowardsWaypoint(Waypoint)); // wait until enemy moves to next waypoint
            yield return new WaitForSeconds(waypointDwellTime); // dwell on 
        }
    }

     private IEnumerator MoveTowardsWaypoint(Waypoint waypoint)
    {
        while (transform.position != waypoint.transform.position)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, waypoint.transform.position, movementPerFrame);
            transform.position = newPosition;
 
            yield return null; // wait until next frame
        }
    }

}
