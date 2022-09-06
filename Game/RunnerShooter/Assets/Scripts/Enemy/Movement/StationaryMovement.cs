using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryMovement : EnemyMovementBase
{
    void Update()
    {
        Move(Time.deltaTime);
    }

    protected override void Move(float _deltaTime)
    {
        Vector2 currentPosition = transform.position;

        currentPosition += moveDir * speed * _deltaTime;

        transform.position = currentPosition;
    }
}
