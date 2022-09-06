using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int moveIndex;

    void Start()
    {
        moveIndex = Random.Range(1, 4);

        AddMovement();
    }

    void AddMovement()
    {
        switch(moveIndex)
        {
            case 3:
                this.gameObject.AddComponent<StationaryMovement>();
                break;
            case 2:
                this.gameObject.AddComponent<MoveWithPlayer>();
                break;
            case 1:
                this.gameObject.AddComponent<MoveToPlayer>();
                break;
            case 0:
                Debug.LogWarning("Move index is out of bounds!");
                Debug.LogWarning("Adding default 'stationary movement'");
                this.gameObject.AddComponent<StationaryMovement>();
                break;
        }
    }
}
