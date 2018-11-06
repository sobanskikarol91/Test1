using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AnimationMode : IState
{
    Transform player;
    List<Transform> points = new List<Transform>();
    Vector2 destination;
    Vector2 direction;
    float currentSpeed;
    int currentPoint = 0;

    public AnimationMode(ref Transform player, ref List<Transform> points)
    {
        this.player = player;
        this.points = points;
    }

    public void Enter()
    {
        SetPlayerOrginPosition();
        SetDestination();
    }

    public void Execute()
    {
        if (Input.GetKey(KeyBind.Acceleration))
            IncreaseVelocity();
        else
            DecreaseVelocity();

        if (!WasLastPoint())
            Move();
    }

    void SetPlayerOrginPosition()
    {
        player.position = points.First().position;
        currentPoint = 1;
    }

    void Move()
    {
        if (currentSpeed == 0) return;

        player.position = Vector2.MoveTowards(player.position, destination, currentSpeed);

        if (Vector2.Distance(player.position, destination) < 0.1f)
        {
            player.position = destination;
            SetDestination();
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

    void SetDestination()
    {
        currentPoint++;
        destination = points[currentPoint].position;
    }

    bool WasLastPoint()
    {
        return points.Count == 0;
    }
}
