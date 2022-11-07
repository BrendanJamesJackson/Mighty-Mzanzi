using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public game_manager gm_script;
    public player_upgrade pu_script;

    private bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInvincible()
    {
        invincible = !invincible;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" || collision.tag == "EnemyBullet") && !invincible)
        {
            gm_script.PlayerDie();
        }
        else if (collision.tag == "rapidfire")
        {
            pu_script.EnableRapid();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "invincible")
        {
            pu_script.EnableInvincible();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "powerful")
        {
            pu_script.EnablePowerful();
            Destroy(collision.gameObject);
        }
    }
}
