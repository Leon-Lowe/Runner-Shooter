using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Enemy Data", fileName = "New Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] float speed = 2f;
    [SerializeField] Color colour;

    public float GetSpeed(){return speed;}
    public Color GetColour(){return colour;}
}
