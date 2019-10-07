using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWayPoint)
    {
        print(towers.Count);
        if(towers.Count < towerLimit)
        {
            InstantiateTower(baseWayPoint);
        }
        else
        {
            MoveExistingTower(baseWayPoint);
        }
    }

    private void InstantiateTower(Waypoint baseWayPoint)
    {
        var newTower = Instantiate(towerPrefab, baseWayPoint.transform.position, Quaternion.identity);
        towers.Enqueue(newTower);
        newTower.baseWayPoint = baseWayPoint;
        baseWayPoint.isPlaceable = false;
        newTower.transform.parent = GameObject.Find("Towers").transform;
    }

    private void MoveExistingTower(Waypoint newBaseWayPoint)
    {
        var oldestTower = towers.Dequeue();

        oldestTower.baseWayPoint.isPlaceable = true;
        newBaseWayPoint.isPlaceable = false;

        oldestTower.baseWayPoint = newBaseWayPoint;
        oldestTower.transform.position = newBaseWayPoint.transform.position;
        towers.Enqueue(oldestTower);
    }
}
