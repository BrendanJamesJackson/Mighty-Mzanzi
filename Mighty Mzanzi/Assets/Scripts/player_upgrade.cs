using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_upgrade : MonoBehaviour
{
    public player_shoot ps_script;
    public player_animation_controller pac_script;
    public player_controller pc_script;
    public game_manager gm_script;

    public GameObject glow;

    public TextMeshProUGUI rapid_text;
    public TextMeshProUGUI powerful_text;
    public TextMeshProUGUI invincible_text;


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
        if (Input.GetKey(KeyCode.Space))
        {
            EnableRapid();
        }

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

    public void EnableRapid()
    {
        rapid_fire = true;
        // Adjust shoot cooldown speed
        // Visual indicator of upgrade
        ps_script.AdjustCooldown(rapid_fire);
        pac_script.SetRapid();
        glow.SetActive(true);
        rapid_text.gameObject.SetActive(true);
    }

    public void DisableRapid()
    {
        rapid_fire = false;
        timer_rapid = duration_rapid;
        // Reset shoot cooldown speed
        // Remove visual indicator of upgrade
        ps_script.AdjustCooldown(rapid_fire);
        pac_script.SetRapid();
        glow.SetActive(false);
        rapid_text.gameObject.SetActive(false);

    }

    public void EnableInvincible()
    {
        invincible = true;
        //Visual indicator of upgrade
        pc_script.SetInvincible();
        glow.SetActive(true);
        invincible_text.color = new Color(1f, 1f, 1f, 1f);
        invincible_text.color = Color.Lerp(invincible_text.color, new Color(1f, 1f, 1f, 0f), 3f);
        invincible_text.gameObject.SetActive(true);

    }

    public void DisableInvincible()
    {
        invincible = false;
        timer_invincible = duration_invincible;
        pc_script.SetInvincible();
        glow.SetActive(false);
        invincible_text.gameObject.SetActive(false);
        // Remove visual indicator of upgrade
    }

    public void EnablePowerful()
    {
        powerful_lasers = true;
        gm_script.global_score_multiplier = 3;
        glow.SetActive(true);
        powerful_text.color = new Color(1f, 1f, 1f, 1f);
        powerful_text.color = Color.Lerp(powerful_text.color, new Color(1f, 1f, 1f, 0f), 3f);
        powerful_text.gameObject.SetActive(true);
        // Adjust laser strength
        // Visual indicator of upgrade
    }

    public void DisablePowerful()
    {
        powerful_lasers = false;
        timer_powerful = duration_powerful;
        gm_script.global_score_multiplier = 1;
        glow.SetActive(false);
        powerful_text.gameObject.SetActive(false);
        // Reset laser strength
        //Remove visual indicator of upgrade
    }

    public bool GetInvincible()
    {
        return invincible;
    }
}
