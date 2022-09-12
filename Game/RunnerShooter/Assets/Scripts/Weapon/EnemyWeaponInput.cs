using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponInput : MonoBehaviour
{
    Transform target;
    float useTimer;
    float useTime = 1.0f;
    Transform trans;

    void Awake()
    {
        trans = transform;    
    }

    void Start()
    {
        target = GameManager.instance.GetPlayerTrans();
    }

    void Update()
    {
        useTimer += Time.deltaTime;
        if(useTimer >= useTime)
        {
            useTimer -= useTime;
            Debug.Log(trans.name + " has fired");
        }
    }
}
