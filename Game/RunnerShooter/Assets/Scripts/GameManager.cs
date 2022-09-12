using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] PlayerMoveTpye playerMoveTpye = PlayerMoveTpye.KeyMove;
    [SerializeField] Transform playerTrans;
    EnemySpawner enemySpawner;

    public enum PlayerMoveTpye{KeyMove, MoveToMouse}

    public PlayerMoveTpye GetPlayerMoveTpye(){return playerMoveTpye;}
    public Transform GetPlayerTrans(){return playerTrans;}
    public void SetEnemySpawner(EnemySpawner _enemySpawner){enemySpawner = _enemySpawner;}
    public EnemySpawner GetEnemySpawner(){return enemySpawner;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
