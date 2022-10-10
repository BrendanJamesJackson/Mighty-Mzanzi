using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class enemy_spawner : MonoBehaviour
{
    private ObjectPool<GameObject> enemyPool;
    public int numEnemies = 5;
    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemyPrefab);
        }, gameObject => {
            gameObject.SetActive(true);
        }, gameObject => {
            gameObject.SetActive(false);
        }, gameObject => {
            Destroy(gameObject);
        }, false, numEnemies, numEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {

    }
}
