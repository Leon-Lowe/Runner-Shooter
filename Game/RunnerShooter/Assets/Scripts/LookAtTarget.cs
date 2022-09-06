using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 2f;

    void Update()
    {
        RotateTo(Time.deltaTime);    
    }

    void RotateTo(float _deltaTime)
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x -transform.position.x ) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * _deltaTime);
    }
}
