using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyTemplate;
    [SerializeField] EnemyData[] enemeis;
    [SerializeField] float maxPosX = 4f;
    [SerializeField] float ySpawnPos = 9f;

    void Start()
    {
        CreateEnemy(ChooseRandomX(), ChooseRandomEnemy());    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){CreateEnemy(ChooseRandomX(), ChooseRandomEnemy());}
    }

    void CreateEnemy(float _xPos, EnemyData _enemyData)
    {
        GameObject newEnemy = Instantiate(enemyTemplate, new Vector2(_xPos, ySpawnPos), Quaternion.identity);
        newEnemy.GetComponent<Enemy>().SetEnemyData(_enemyData);
    }

    float ChooseRandomX()
    {
        return Random.Range(-maxPosX, maxPosX);
    }

    EnemyData ChooseRandomEnemy()
    {
        int randEnemyIndex = Random.Range(0, enemeis.Length);
        return enemeis[randEnemyIndex];
    }
}
