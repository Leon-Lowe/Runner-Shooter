using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject enemyTemplate;
    [SerializeField] EnemyData[] enemies;
    [SerializeField] int maxEnemies = 10;
    [Header("Spawn Position Settings")]
    [SerializeField] float maxPosX = 4f;
    [SerializeField] float ySpawnPos = 9f;
    [Header("Spawn Timer Settings")]
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 1.5f;
    List<Transform> enemiesInGame;
    float spawnTimer;
    float currentSpawnTime;

    public List<Transform> GetEnemiesInGame(){return enemiesInGame;}

    void Awake()
    {
        enemiesInGame = new List<Transform>();
    }

    void Start()
    {
        GameManager.instance.SetEnemySpawner(this);
        
        currentSpawnTime = ChooseSpawnTime();
    }

    void Update()
    {
        if(enemiesInGame.Count < maxEnemies){HandleSpawn(Time.deltaTime);}
    }

    void HandleSpawn(float _deltaTime)
    {
        spawnTimer += _deltaTime;
        if (spawnTimer >= currentSpawnTime)
        {
            CreateEnemy(ChooseRandomX(), ChooseRandomEnemy());
            spawnTimer -= currentSpawnTime;
            currentSpawnTime = ChooseSpawnTime();
        }
    }

    void CreateEnemy(float _xPos, EnemyData _enemyData)
    {
        GameObject newEnemy = Instantiate(enemyTemplate, new Vector2(_xPos, ySpawnPos), Quaternion.identity);
        newEnemy.name = "Enemy_" + enemiesInGame.Count;
        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.SetMySpawner(this);
        newEnemyComponent.SetEnemyData(_enemyData);
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

    float ChooseSpawnTime(){return Random.Range(minSpawnTime, maxSpawnTime);}

    public void RemoveFromEnemiesListByReference(Transform _transformRef)
    {
        enemiesInGame.Remove(_transformRef);
    }
}
