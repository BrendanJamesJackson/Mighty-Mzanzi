using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_controller : MonoBehaviour
{
    public game_manager gm_script;
    public AudioSource enemy_death_audio;

    private Rigidbody2D laser_rb;
    public float laser_speed = 10f;
    public int laser_strength = 1;

    // Start is called before the first frame update
    void Start()
    {
        laser_rb = gameObject.GetComponent<Rigidbody2D>();
        gm_script = GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>();
        enemy_death_audio = GameObject.FindGameObjectWithTag("enemyaudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        laser_rb.velocity = new Vector2(laser_speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (gm_script.global_score_multiplier * laser_strength >= collision.GetComponent<enemy_controller>().GetHealth())
            {
                collision.GetComponent<enemy_controller>().enemyDie();
                enemy_death_audio.Play();
            }
            else
            {
                collision.GetComponent<enemy_controller>().SetHealth(collision.GetComponent<enemy_controller>().GetHealth() - (gm_script.global_score_multiplier * laser_strength));
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
