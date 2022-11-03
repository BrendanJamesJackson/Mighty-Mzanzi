using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class play_scene : MonoBehaviour
{    
    public void LoadByIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1;
    }
}
