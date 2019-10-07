using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true; //state todo make private

    [SerializeField] GameObject enemyBlock;
    Waypoint searchCenter;
    [SerializeField] Waypoint StartWayPoint, EndWayPoint;

    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            CalculatePath();
        }
        return path;

    }

    private void CalculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        SetAsPath(EndWayPoint);
        ReplacePathBlocks(EndWayPoint);

        Waypoint previous = EndWayPoint.exploredFrom;
        while(previous != StartWayPoint)
        {
            //add intermediate waypoints
            SetAsPath(previous);
            ReplacePathBlocks(previous);
            previous = previous.exploredFrom;
        }
        //add start waypoint
        SetAsPath(StartWayPoint);
        ReplacePathBlocks(StartWayPoint);
        //reverse the list
        path.Reverse();
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;  //dont allow tower placement
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(StartWayPoint);


        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void ReplacePathBlocks(Waypoint waypoint)
    {
        var child = waypoint.transform.Find("Block_Friendly").gameObject;
        var newEnemyBlock = Instantiate(enemyBlock, child.transform.position, child.transform.rotation);
        newEnemyBlock.transform.parent = waypoint.transform;
        Destroy(child);
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == EndWayPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
            //print("Queueing " + neighbour);
        }
    }


    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();  //anything with waypoint script will be found
        foreach(Waypoint waypoint in waypoints)
        {
            //overlapping blocks?
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Overlapping block: " + waypoint);
            }
            else
            {
                //add to dictionary
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
