using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] MoveTpye playerMoveTpye = MoveTpye.KeyMove;
    [SerializeField] Transform playerTrans;

    public enum MoveTpye{KeyMove, MoveToMouse}

    public MoveTpye GetPlayerMoveTpye(){return playerMoveTpye;}
    public Transform GetPlayerTrans(){return playerTrans;}

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
