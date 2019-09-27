using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase] //when object is clicked on, the cube is always selected

[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    //[SerializeField] Waypoint StartingBlock;
    //[SerializeField] Waypoint EndingBlock;

    Waypoint wayPoint;

    private void Awake()
    {
        wayPoint = GetComponent<Waypoint>();
    }

    private void Start()
    {

    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = wayPoint.GetGridSize();
        transform.position = new Vector3(wayPoint.GetGridPos().x * gridSize, 0f, wayPoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        int gridSize = wayPoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = wayPoint.GetGridPos().x + "," + wayPoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
