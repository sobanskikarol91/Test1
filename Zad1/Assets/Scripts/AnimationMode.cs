using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AnimationMode : IState
{
    Transform player;
    List<Transform> points = new List<Transform>();
    Vector2 destination;
    float currentSpeed;
    int currentPoint;

    public AnimationMode(ref Transform player, ref List<Transform> points)
    {
        this.player = player;
        this.points = points;
    }

    public void Enter()
    {
        currentSpeed = currentPoint = 0;
        SetPlayerOrginPosition();
        SetNewDestination();
    }

    public void Execute()
    {
        if (Input.GetKey(KeyBind.Acceleration))
            IncreaseVelocity();
        else
            DecreaseVelocity();

        Move();
    }

    public void Exit()
    {
        DestroyPoints();
    }

    void SetPlayerOrginPosition()
    {
        player.position = points.First().position;
    }

    void Move()
    {
        if (currentSpeed == 0) return;

        player.position = Vector2.MoveTowards(player.position, destination, currentSpeed);

        if (Vector2.Distance(player.position, destination) < 0.1f)
        {
            player.position = destination;
            SetNewDestination();
        }
    }

    void IncreaseVelocity()
    {
        currentSpeed += Time.deltaTime * Settings.SpeedFactor;
    }

    void DecreaseVelocity()
    {
        currentSpeed -= Time.deltaTime * Settings.SpeedFactor;
        if (currentSpeed < 0) currentSpeed = 0;
    }

    void SetNewDestination()
    {
        if (WasLastPoint())
            GameManager.instance.ChangeToEdit();
        else
        {
            currentPoint++;
            destination = points[currentPoint].position;
        }
    }

    bool WasLastPoint()
    {
        return currentPoint == points.Count - 1;
    }

    void DestroyPoints()
    {
        points.ForEach(p => GameObject.Destroy(p.gameObject));
        points.Clear();
    }
}
