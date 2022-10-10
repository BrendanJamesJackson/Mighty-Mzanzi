using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour
{
    public GameObject laser_prefab;
    public Transform shoot_pos;
    public float cooldown;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (timer <= 0)
        {
            Instantiate(laser_prefab, shoot_pos.position, shoot_pos.rotation);
            timer = cooldown;
        }
    }
}
