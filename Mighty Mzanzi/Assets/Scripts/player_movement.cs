using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Rigidbody2D player_rb;

    public float jump_force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Jump();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            player_rb.velocity *= 0.25f;
        }
    }

    void Jump()
    {
        player_rb.AddForce(new Vector2(0, jump_force), ForceMode2D.Force);
    }

    void Fly()
    {

    }
}
