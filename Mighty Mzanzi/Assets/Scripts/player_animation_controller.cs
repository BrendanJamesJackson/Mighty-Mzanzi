using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation_controller : MonoBehaviour
{
    public Rigidbody2D player_rb;

    public bool upwards;
    public bool downwards;

    public Animator player_animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player_rb.velocity.y >0)
        {
            upwards = true;
            downwards = false;
        }
        else if (player_rb.velocity.y < 0)
        {
            upwards = false;
            downwards = true;
        }
        else if (player_rb.velocity.y == 0)
        {
            upwards = false;
            downwards = false;
        }

        player_animator.SetBool("upwards",upwards);
        player_animator.SetBool("downwards", downwards);
    }
}
