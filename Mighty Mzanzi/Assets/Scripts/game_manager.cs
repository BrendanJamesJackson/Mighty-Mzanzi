using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public int player_score;
    public int score_interval;
    public int score_increase;
    private float score_timer;

    public int global_score_multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_timer += Time.deltaTime;
        if (score_timer >= score_interval)
        {
            score_timer = 0f;
            player_score += score_increase;
        }
    }

    public void EnemyBonus(int bonus)
    {
        player_score += bonus;
    }

    public void PlayerDie()
    {
        Debug.Log("dead");
    }
}
