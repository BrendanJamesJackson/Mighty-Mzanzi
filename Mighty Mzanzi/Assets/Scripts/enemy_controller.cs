using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_controller : MonoBehaviour
{

    public int enemy_health;
    public int enemy_bonus;

    private int max_health;
    private float healthBarVal = 1f;

    public game_manager gm_script;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        gm_script = GameObject.FindGameObjectWithTag("GameManager").GetComponent<game_manager>();        
        max_health = enemy_health;
        healthBar = GetComponentInChildren<Image>(false);
    }

    private void Update()
    {
        
    }

    public void enemyDie()
    {
        //particle effect
        //sound
        gm_script.EnemyBonus(enemy_bonus);
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return enemy_health;
    }

    public void SetHealth(int new_health)
    {
        enemy_health = new_health;
    }

    public void decHealthBar()
    {
        healthBarVal = (float)enemy_health / max_health;
        healthBar.fillAmount = healthBarVal;
    }
}
