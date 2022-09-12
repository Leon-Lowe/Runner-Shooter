using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 2f;
    Transform trans;

    void Awake()
    {
        trans = transform;    
    }

    public void SetTarget(Transform _target) {target = _target;}

    void Update()
    {
        RotateTo(Time.deltaTime);    
    }

    void RotateTo(float _deltaTime)
    {
        float angle = Mathf.Atan2(target.position.y - trans.position.y, target.position.x -trans.position.x ) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        transform.rotation = Quaternion.RotateTowards(trans.rotation, targetRotation, speed * _deltaTime);
    }
}
