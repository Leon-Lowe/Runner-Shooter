using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] MoveTpye moveTpye = MoveTpye.KeyMove;
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 bounds;

    void Update()
    {
        if(moveTpye == MoveTpye.KeyMove) {KeyMove();}
        if(moveTpye == MoveTpye.MoveToMouse) {MoveToMouse();}
    }

    void MoveToMouse()
    {
        Vector2 currentPosition = transform.position;
        
        currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition = ContainToBounds(currentPosition);

        transform.position = currentPosition;
    }

    void KeyMove()
    {
        Vector2 moveDir = GetMoveDir();
        Move(Time.deltaTime, moveDir);
    }

    void Move(float _deltaTime, Vector2 _moveDir)
    {
        Vector2 currentPosition = transform.position;

        currentPosition += _moveDir * _deltaTime * speed;
        currentPosition = ContainToBounds(currentPosition);

        transform.position = currentPosition;
    }

    Vector2 ContainToBounds(Vector2 _toContain)
    {
        Vector2 toContain = _toContain;

        if(toContain.x > bounds.x) {toContain.x = bounds.x;}
        if(toContain.x < -bounds.x) {toContain.x = -bounds.x;}
        if(toContain.y > bounds.y) {toContain.y = bounds.y;}
        if(toContain.y < -bounds.y) {toContain.y = -bounds.y;}

        return toContain;
    }

    Vector2 GetMoveDir()
    {
        Vector2 tempDir = Vector2.zero;
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {tempDir.y += 1;}
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {tempDir.y -= 1;}
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {tempDir.x -= 1;}
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {tempDir.x += 1;}

        return tempDir.normalized;
    }

    public enum MoveTpye{KeyMove, MoveToMouse}
}
