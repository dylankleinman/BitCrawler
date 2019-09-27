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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer =  transform.Find("Top").GetComponent<MeshRenderer>();  //looks at children
        topMeshRenderer.material.color = color;
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (isExplored)
        {
            //neighbour.SetTopColor(Color.blue);  // todo set top color
        }
    }
}
