using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class play_scene : MonoBehaviour
{
    
    public void LoadGame(int SceneIndex)
    {
        game_loader.instance.LoadGame(SceneIndex);
    }
    
    public void LoadByIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1;
    }
}
