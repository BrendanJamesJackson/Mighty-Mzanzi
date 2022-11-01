using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_spawner : MonoBehaviour
{

    public GameObject[] obsts;

    private float timer = 0f;
    public float spawn_rate;
    public Transform spawnpoint;

    public int obst_types;
    private int random_obst;

    // Start is called before the first frame update
    void Start()
    {
        spawn_rate = Random.Range(2f, 9f);
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
            random_obst = Random.Range(0, obst_types);
            GameObject temp = Instantiate(obsts[random_obst], spawnpoint.position, Quaternion.identity);
            spawn_rate = Random.Range(2f, 9f);
            timer = 0f;
        }
    }
}
