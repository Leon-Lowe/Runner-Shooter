using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    int moveIndex;
    EnemyData enemyData;
    EnemyMovementBase movement;
    EnemySpawner mySpawner;
    Transform trans;

    public void SetEnemyData(EnemyData _enemyData){enemyData = _enemyData;}
    public void SetMySpawner(EnemySpawner _mySpawner){mySpawner = _mySpawner;}

    void Awake()
    {
        trans = transform;    
    }

    void Start()
    {
        moveIndex = Random.Range(1, 4);
        AddMovement();

        movement.SetSpeed(enemyData.GetSpeed());
        this.gameObject.GetComponent<LookAtTarget>().SetTarget(GameManager.instance.GetPlayerTrans());

        spriteRenderer.color = enemyData.GetColour();
    }

    void Update()
    {
        if(trans.position.y <= -10){Despawn();}    
    }

    void Despawn()
    {
        mySpawner.RemoveFromEnemiesListByReference(trans);
        Destroy(gameObject);
    }

    void AddMovement()
    {
        switch(moveIndex)
        {
            case 3:
                movement = this.gameObject.AddComponent<StationaryMovement>();
                break;
            case 2:
                movement = this.gameObject.AddComponent<MoveWithPlayer>();
                break;
            case 1:
                movement = this.gameObject.AddComponent<MoveToPlayer>();
                break;
            case 0:
                Debug.LogWarning("Move index is out of bounds!");
                Debug.LogWarning("Adding default 'stationary movement'");
                movement = this.gameObject.AddComponent<StationaryMovement>();
                break;
        }
    }
}
