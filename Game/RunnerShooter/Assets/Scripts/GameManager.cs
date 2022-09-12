using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] PlayerMoveTpye playerMoveTpye = PlayerMoveTpye.KeyMove;
    [SerializeField] Transform playerTrans;

    public enum PlayerMoveTpye{KeyMove, MoveToMouse}

    public PlayerMoveTpye GetPlayerMoveTpye(){return playerMoveTpye;}
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
