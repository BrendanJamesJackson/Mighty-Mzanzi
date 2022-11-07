using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shoot : MonoBehaviour
{
    public float fireRate = 3f;
    public float minRate = 1.5f;
    public float maxRate = 3f;

    private float timer = 0f;

    public GameObject bullet;

    public Transform bulletSP;

    public Animator shootanim;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = Random.Range(minRate, maxRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= fireRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(bullet, bulletSP.position, Quaternion.identity);
            shootanim.SetTrigger("shoot");
            timer = 0f;
            fireRate = Random.Range(minRate, maxRate);
        }
    }


}
