using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryMovement : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] MoveDirection moveDirection = MoveDirection.Down;
    Vector2 moveDir;

    public enum MoveDirection{Up, Down, Left, Right}

    void Start()
    {
        SetMoveDir();    
    }

    void Update()
    {
        Move(Time.deltaTime);
    }

    void Move(float _deltaTime)
    {
        Vector2 currentPosition = transform.position;

        currentPosition += moveDir * speed * _deltaTime;

        transform.position = currentPosition;
    }

    void SetMoveDir()
    {
        if(moveDirection == MoveDirection.Up) {moveDir = new Vector2(0, 1);}
        if(moveDirection == MoveDirection.Down) {moveDir = new Vector2(0, -1);}
        if(moveDirection == MoveDirection.Right) {moveDir = new Vector2(1, 0);}
        if(moveDirection == MoveDirection.Left) {moveDir = new Vector2(-1, 0);}
    }
}
