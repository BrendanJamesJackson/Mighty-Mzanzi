using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class enemy_spawner : MonoBehaviour
{
    private ObjectPool<GameObject> enemyPool;
    public int numEnemies = 5;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform outOfViewPoint;

    private float timer = 0f;
    public float spawnRate = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }, enemyPrefab => {
            enemyPrefab.transform.position = spawnPoint.position;
            enemyPrefab.gameObject.SetActive(true);
        }, enemyPrefab => {
            enemyPrefab.gameObject.SetActive(false);
        }, enemyPrefab => {
            Destroy(enemyPrefab);
        }, false, numEnemies, numEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            enemyPool.Get();
            timer = 0f;
        }

        if (gameObject.transform.position.x >= outOfViewPoint.position.x) //gotta release when enemy dies as well
        {
            enemyPool.Release(enemyPrefab);
        }
    }

    private void Spawn()
    {

    }
}
