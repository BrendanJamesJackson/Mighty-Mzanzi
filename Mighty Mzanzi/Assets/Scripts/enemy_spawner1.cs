using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner1 : MonoBehaviour
{
    private List<GameObject> enemyPool;
    public GameObject enemy1;
    //public int maxEnemies = 10;
    //private int numEnemies = 0;
    public Transform spawnPoint;    
    private float timer = 0f;
    public float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy1, spawnPoint.position, Quaternion.identity);
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
            Instantiate(enemy1, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }        
    }


}
