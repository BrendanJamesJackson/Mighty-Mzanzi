using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_spawner : MonoBehaviour
{
    public GameObject[] powerups;
    public Transform[] spawnpoints;
    private float timer = 0f;
    public float spawn_rate;

    public int pickup_types;
    private int random_pickup;

    // Start is called before the first frame update
    void Start()
    {
        spawn_rate = Random.Range(3f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= spawn_rate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            random_pickup = Random.Range(0, pickup_types);
            Instantiate(powerups[random_pickup], spawnpoints[Random.Range(0, 4)].position, Quaternion.identity);
            spawn_rate = Random.Range(3f, 12f);
            timer = 0f;
        }
    }
}
