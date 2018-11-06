using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EditMode : IState
{
    GameObject pointPrefab;
    List<Transform> points;

    public EditMode(GameObject pointPrefab, ref List<Transform> points)
    {
        this.pointPrefab = pointPrefab;
        this.points = points;
    }

    public void Enter()
    {

    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyBind.CreatePoint) && !EventSystem.current.IsPointerOverGameObject())
            CreatePoint();
    }

    public void Exit()
    {
      
    }

    public void CreatePoint()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 pointPos = Camera.main.ScreenToWorldPoint(mousePos);
        Transform newPoint = GameObject.Instantiate(pointPrefab, pointPos, Quaternion.identity).transform;
        points.Add(newPoint);
    }


}
