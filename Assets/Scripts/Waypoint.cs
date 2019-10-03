using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    Vector2Int gridPos;
    const int gridSize = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / 10f),
            Mathf.RoundToInt(transform.position.z / 10f)
        );
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        print(GetGridPos().x + "," + GetGridPos().y);
    }

}
