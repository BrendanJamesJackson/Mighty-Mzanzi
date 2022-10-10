using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_controller : MonoBehaviour
{
    private Rigidbody2D laser_rb;
    public float laser_speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        laser_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        laser_rb.velocity = new Vector2(laser_speed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
