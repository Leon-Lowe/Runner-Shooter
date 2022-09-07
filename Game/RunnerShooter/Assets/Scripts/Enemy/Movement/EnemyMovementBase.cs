using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBase : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected MoveDirection moveDirection = MoveDirection.Down;
    protected Vector2 moveDir;

    public enum MoveDirection{Up, Down, Left, Right}

    public void SetSpeed(float _speed){speed = _speed;}

    void Awake()
    {
        SetMoveDir();    
    }

    protected virtual void Move(float _deltaTime)
    {
        Debug.Log("Moving");
    }

    protected void SetMoveDir()
    {
        if(moveDirection == MoveDirection.Up) {moveDir = new Vector2(0, 1);}
        if(moveDirection == MoveDirection.Down) {moveDir = new Vector2(0, -1);}
        if(moveDirection == MoveDirection.Right) {moveDir = new Vector2(1, 0);}
        if(moveDirection == MoveDirection.Left) {moveDir = new Vector2(-1, 0);}
    }
}
