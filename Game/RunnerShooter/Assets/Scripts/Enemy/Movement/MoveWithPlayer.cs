using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : EnemyMovementBase
{
    [SerializeField] float maxPosY = 8f;
    [SerializeField] float minPosY = -8f;
    [SerializeField] float maxPositionPadding = 0.2f;
    Vector2 randPos;
    bool reachedY;

    void Start()
    {
        randPos = new Vector2(trans.position.x, Random.Range(minPosY, maxPosY));
        reachedY = false;
    }

    void Update()
    {
        if(!reachedY) {Move(Time.deltaTime);}
    }

    protected override void Move(float _deltaTime)
    {
        Vector2 currentPosition = trans.position;

        currentPosition += moveDir * speed * _deltaTime;

        trans.position = currentPosition;

        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector2.Distance(trans.position, randPos) <= maxPositionPadding) {reachedY = true;}
    }
}
