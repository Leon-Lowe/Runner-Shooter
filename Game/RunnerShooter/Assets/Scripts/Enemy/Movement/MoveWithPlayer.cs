using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : EnemyMovementBase
{
    [SerializeField] float maxPosY = 8f;
    [SerializeField] float minPosY = -8f;
    [SerializeField] float maxPadding = 0.2f;
    Vector2 randPos;
    bool reachedY;

    void Start()
    {
        randPos = new Vector2(transform.position.x, Random.Range(minPosY, maxPosY));
        reachedY = false;
        Debug.Log(randPos);
    }

    void Update()
    {
        if(!reachedY) {Move(Time.deltaTime);}
    }

    protected override void Move(float _deltaTime)
    {
        Vector2 currentPosition = transform.position;

        currentPosition += moveDir * speed * _deltaTime;

        transform.position = currentPosition;

        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector2.Distance(transform.position, randPos) <= maxPadding) {reachedY = true;}
    }
}
