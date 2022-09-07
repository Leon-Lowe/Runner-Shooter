using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyTemplate;
    [SerializeField] EnemyData[] enemies;
    [SerializeField] int maxEnemies = 10;
    [SerializeField] float maxPosX = 4f;
    [SerializeField] float ySpawnPos = 9f;
    List<Transform> enemiesInGame;

    void Awake()
    {
        enemiesInGame = new List<Transform>();
    }

    void Start()
    {
        CreateEnemy(ChooseRandomX(), ChooseRandomEnemy());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && enemiesInGame.Count < maxEnemies)
        {
            CreateEnemy(ChooseRandomX(), ChooseRandomEnemy());
        }
    }

    void CreateEnemy(float _xPos, EnemyData _enemyData)
    {
        GameObject newEnemy = Instantiate(enemyTemplate, new Vector2(_xPos, ySpawnPos), Quaternion.identity);
        newEnemy.GetComponent<Enemy>().SetEnemyData(_enemyData);
        enemiesInGame.Add(newEnemy.transform);
    }

    float ChooseRandomX()
    {
        return Random.Range(-maxPosX, maxPosX);
    }

    EnemyData ChooseRandomEnemy()
    {
        int randEnemyIndex = Random.Range(0, enemies.Length);
        return enemies[randEnemyIndex];
    }
}
