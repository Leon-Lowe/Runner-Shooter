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
        Vector2 currentPosition = trans.position;

        currentPosition += moveDir * speed * _deltaTime;

        trans.position = currentPosition;
    }
}
