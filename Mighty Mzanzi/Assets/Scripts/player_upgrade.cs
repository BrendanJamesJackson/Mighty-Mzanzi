using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_upgrade : MonoBehaviour
{
    public player_shoot ps_script;

    public bool rapid_fire = false;
    private bool invincible = false;
    private bool powerful_lasers = false;

    private float timer_rapid;
    private float timer_invincible;
    private float timer_powerful;

    public float duration_rapid;
    public float duration_invincible;
    public float duration_powerful;

    // Start is called before the first frame update
    void Start()
    {
        timer_rapid = duration_rapid;
        timer_invincible = duration_invincible;
        timer_powerful = duration_powerful;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKey(KeyCode.Space))
        {
            EnableRapid();
        }*/

        if (rapid_fire)
        {
            timer_rapid -= Time.deltaTime;
            if (timer_rapid <= 0)
            {
                DisableRapid();
            }
        }
        if (invincible)
        {
            timer_invincible -= Time.deltaTime;
            if (timer_invincible <= 0)
            {
                DisableInvincible();
            }
        }
        if (powerful_lasers)
        {
            timer_powerful -= Time.deltaTime;
            if (timer_powerful<= 0)
            {
                DisablePowerful();
            }
        }
    }

    void EnableRapid()
    {
        rapid_fire = true;
        // Adjust shoot cooldown speed
        // Visual indicator of upgrade
        ps_script.AdjustCooldown(rapid_fire);
    }

    void DisableRapid()
    {
        rapid_fire = false;
        timer_rapid = duration_rapid;
        // Reset shoot cooldown speed
        // Remove visual indicator of upgrade
        ps_script.AdjustCooldown(rapid_fire);
    }

    void EnableInvincible()
    {
        invincible = true;
        //Visual indicator of upgrade
    }

    void DisableInvincible()
    {
        invincible = false;
        timer_invincible = duration_invincible;
        // Remove visual indicator of upgrade
    }

    void EnablePowerful()
    {
        powerful_lasers = true;
        // Adjust laser strength
        // Visual indicator of upgrade
    }

    void DisablePowerful()
    {
        powerful_lasers = false;
        timer_powerful = duration_powerful;
        // Reset laser strength
        //Remove visual indicator of upgrade
    }

    public bool GetInvincible()
    {
        return invincible;
    }
}
