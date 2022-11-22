using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class TestCall : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField, Multiline(10)]
    private string result;

    public void Run()
    {
        var gameManager = game_manager.Instance;
        var penroseAPI = gameManager.PenroseAPIManager;
        //penroseAPI.TestAPIResponse(OnSuccessful, OnFail);

        Debug.Log("Checking Valid Username.....");
        penroseAPI.TryCheckUsername(OnSuccessful, OnFail);
    }

    private void OnFail(string result)
    {
        Debug.LogError($"Fail: {result}");
    }

    private void OnSuccessful(string result)
    {
        Debug.Log($"Successful {result}");
        this.result = result;

        var output = JsonUtility.FromJson<Dictionary<string,string>>(this.result);
        Debug.Log(output);

        foreach(var kvp in output)
        {
            Debug.Log($"{kvp.Key} -- {kvp.Value}");
        }

       /* var output = JsonUtility.FromJson<Dictionary<string, string>>(result);
       // var output2 = JsonSerializer.Deserialize<Dictionary<string, string>>(result);

        Debug.Log(output2);

        Debug.Log(output2.Keys.Count);
            
        foreach (KeyValuePair<string, string> kvp in output2)
        {
            Debug.Log($"{kvp.Key}, {kvp.Value}");
        }*/
    }
}
