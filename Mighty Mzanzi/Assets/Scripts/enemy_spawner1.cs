using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner1 : MonoBehaviour
{
    private List<GameObject> enemyPool;
    public GameObject[] enemies;
    //public int maxEnemies = 10;
    //private int numEnemies = 0;
    public Transform[] spawnPoints;    
    private float timer = 0f;
    public float spawnRate = 2f;

    public int enemy_types;
    public int enemy_spawns;
    private int random_enemy;

    // Start is called before the first frame update
    void Start()
    {
        random_enemy = Random.Range(0,enemy_types);
        Instantiate(enemies[random_enemy], spawnPoints[random_enemy].position, Quaternion.identity);
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
            random_enemy = Random.Range(0, enemy_types);
            if (random_enemy == 0 || random_enemy == 1)
            {
                Instantiate(enemies[random_enemy], spawnPoints[0].position, Quaternion.identity);
                Debug.Log("enem"+random_enemy);
            }
            else
            {
                Instantiate(enemies[random_enemy], spawnPoints[Random.Range(1, enemy_spawns)].position, Quaternion.identity);
            }
            Debug.Log(random_enemy);
            timer = 0f;
        }        
    }


}
