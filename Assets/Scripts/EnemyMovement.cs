using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<Waypoint> path;
    // Start is called before the first frame update

    void Start()
    {
        //StartCoroutine(FollowPath());
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol");
        foreach (Waypoint Waypoint in path)
        {
            //print("Vising block: " + Waypoint.name);
            transform.position = Waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Finishing Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
