using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : EnemyMovementBase
{
    [SerializeField] float stopDistance = 1f;
    bool withinRangeOfPlayer = false;
    Transform trans;

    void Awake()
    {
        trans = transform;    
    }

    void Update()
    {
        withinRangeOfPlayer = CloseToPlayer();
        if(!withinRangeOfPlayer)
        {
            moveDir = GetDirectionToPlayer();
            Move(Time.deltaTime);
        }
    }

    protected override void Move(float _deltaTime)
    {
        Vector2 currentPosition = trans.position;
        currentPosition += moveDir * speed * _deltaTime;
        trans.position = currentPosition;
    }

    Vector2 GetDirectionToPlayer()
    {
        return -(trans.position - GameManager.instance.GetPlayerTrans().position).normalized;
    }

    bool CloseToPlayer()
    {
        if(Vector2.Distance(trans.position, GameManager.instance.GetPlayerTrans().position) <= stopDistance)
        {
            return true;
        }

        return false;
    }
}
