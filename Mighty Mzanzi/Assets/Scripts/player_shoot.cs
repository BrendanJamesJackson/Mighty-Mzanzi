using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour
{
    public player_animation_controller pac_script;

    public GameObject laser_prefab;
    public Transform shoot_pos;
    public float cooldown;
    public float rapid_cooldown;

    private float current_cooldown;
    private float timer;
    private float laser_strength;

    public bool powerful = false;
    public Sprite powerlaser;

    // Start is called before the first frame update
    void Start()
    {
        current_cooldown = cooldown;
        timer = current_cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void AdjustCooldown(bool set_rapid)
    {
        if (set_rapid)
        {
            current_cooldown = rapid_cooldown;
        }
        else if (!set_rapid)
        {
            current_cooldown = cooldown;
        }
    }

    public void SetPowerful()
    {
        powerful = !powerful;
    }

    public void Shoot()
    {
        if (timer <= 0)
        {
            GameObject tempshot = Instantiate(laser_prefab, shoot_pos.position, shoot_pos.rotation);
            timer = current_cooldown;
            pac_script.ShootAnim();

            if (powerful)
            {
                tempshot.GetComponent<SpriteRenderer>().sprite = powerlaser;
            }
        }
    }
}
