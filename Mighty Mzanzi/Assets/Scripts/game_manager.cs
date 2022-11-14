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

    public GameObject left_input1;
    public GameObject left_input2;
    public GameObject right_input1;
    public GameObject right_input2;
    public GameObject hair;

    public Animator player_anim;

    // Start is called before the first frame update

    void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    public void ShowInstructions()
    {
        Time.timeScale = 0;
        Instructions.SetActive(true);

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
        finalscore_text.text = "You Were Defeated!!! \n Score: \n" + player_score;
        left_input1.SetActive(false);
        left_input2.SetActive(false);
        right_input1.SetActive(false);
        right_input2.SetActive(false);
        GameObject[] enems = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i=0;i<enems.Length;i++)
        {
            enems[i].SetActive(false);
        }
        hair.SetActive(false);
        player_anim.SetTrigger("die");
        StartCoroutine(wait()); 
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 0;
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
