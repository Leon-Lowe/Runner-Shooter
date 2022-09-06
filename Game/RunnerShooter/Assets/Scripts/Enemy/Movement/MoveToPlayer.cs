using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector2 moveDir;

    void Update()
    {
        moveDir = GetDirectionToPlayer();
        Move(Time.deltaTime);    
    }

    void Move(float _deltaTime)
    {
        Vector2 currentPosition = transform.position;
        currentPosition += moveDir * speed * _deltaTime;
        transform.position = currentPosition;
    }

    Vector2 GetDirectionToPlayer()
    {
        return -(transform.position - GameManager.instance.GetPlayerTrans().position).normalized;
    }
}
