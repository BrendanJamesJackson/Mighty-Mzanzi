using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_manager : MonoBehaviour
{
    public int player_score;
    public int score_interval;
    public int score_increase;
    private float score_timer;

    public int global_score_multiplier = 1;

    public TextMeshProUGUI score_text;
    public GameObject DeathScreen;
    public TextMeshProUGUI finalscore_text;
    public GameObject Instructions;
    public GameObject Pause_Menu;

    // Start is called before the first frame update

    void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        
    }

    public void BeginGame()
    {
        Instructions.SetActive(false);
        Time.timeScale = 1;
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
        score_text.text = "Score: \n" + player_score;
    }

    public void EnemyBonus(int bonus)
    {
        player_score += bonus;
    }

    public void PlayerDie()
    {
        Debug.Log("dead");
        Time.timeScale = 0;
        finalscore_text.text = "You Were Defeated!!! \n Score: \n" + player_score;
        DeathScreen.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Pause_Menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Pause_Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void AudioEnable()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
