using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_loader : MonoBehaviour
{
    public static game_loader instance;
    public GameObject progressCanvas;
    public Image progressBar;
    private float target;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public async void LoadGame(int index)
    {
        progressBar.fillAmount = 0f;
        target = 0f;

        var scene = SceneManager.LoadSceneAsync(index);
        scene.allowSceneActivation = false;

        progressCanvas.SetActive(true);

        do
        {
            await System.Threading.Tasks.Task.Delay(1000); //don't forget to remove
            target = scene.progress;
        } while (scene.progress < 0.9f);

        await System.Threading.Tasks.Task.Delay(2000); //don't forget to remove

        scene.allowSceneActivation = true;

        progressCanvas.SetActive(false);
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 0.5f * Time.deltaTime);
    }
}
