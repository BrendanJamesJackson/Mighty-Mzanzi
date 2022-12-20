using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public static class PenroseAPIBridge
{
    public const string CHECK_USER = "https://c5ir2jqn75.execute-api.eu-west-2.amazonaws.com/mzansi-api/checkUser?unique_id=";
    public const string SEND_SCORE = "https://c5ir2jqn75.execute-api.eu-west-2.amazonaws.com/mzansi-api/submitScore";

    public static string UniqueId { get; private set; }
    public static string GameId { get; private set; }

    private static Action<string> usernameRetrievalSuccessful;
    private static Action usernameRetrievalFailed;

    private static Action scoreUploadSuccessful;
    private static Action scoreUploadFailed;

    public static void GetUrlParameters()
    {
        Dictionary<string, string> parameters = HREF_fetch.GetBrowserParameters();

        if (parameters.Count == 0)
        {
            return;
        }

        Debug.Log(parameters.Count + " = kvp count");
        foreach (KeyValuePair<string, string> kvp in parameters)
        {
            Debug.Log($"{kvp.Key} {kvp.Value}");
        }

        const string UNIQUE_ID = "unique_id";
        const string GAME_ID = "game_id";

        if (parameters.ContainsKey(UNIQUE_ID))
        {
            UniqueId = parameters[UNIQUE_ID];
            Debug.Log($"----------{parameters[UNIQUE_ID]}");
            
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            UniqueId = "f6f56f6-1139212-d2c71d7d-e297f8-bb71";
#endif
        }

        if (parameters.ContainsKey(GAME_ID))
        {
            GameId = parameters[GAME_ID];
        }
    }

    public static IEnumerator RequestGet(string uri, Action<string> onSuccessful, Action<string> onFail)
    {
        Debug.Log(uri);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("<color=green>" + pages[page] + ":\nReceived: " + webRequest.downloadHandler.text + "</color>");
                if (onSuccessful != null)
                {
                    onSuccessful(webRequest.downloadHandler.text);
                }
            }
            else
            {
                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                if (onFail != null)
                {
                    onFail(webRequest.error);
                }
            }
        }
    }

    public static IEnumerator CheckUser(Action<string> onSuccessful, Action<string> onFail)
    {
        var uri = $"{CHECK_USER}{UniqueId}";
        yield return RequestGet(uri, onSuccessful, onFail);
    }

    public static IEnumerator PostScore(int score, Action<string> onSuccessful, Action<string> onFail)
    {
        /* WWWForm form = new WWWForm();
        form.AddField("unique_id", UniqueId);
        form.AddField("score", score);
        form.AddField("game_id", GameId);*/
        
        Debug.Log($"unique_id: {UniqueId}");
        Debug.Log($"score: {score}");
        Debug.Log($"game_id: {GameId}");

        GameData instanceData = new GameData()
        {
            unique_id = UniqueId,
            score = score,
            game_id = GameId
        };
        
        
        //string jsonData = JsonUtility.ToJson(instanceData);
        string jsonData = JsonConvert.SerializeObject(instanceData);
        Debug.Log(jsonData);
        
        /*
         * Access-Control-Allow-Origin:  http://127.0.0.1:3000
Access-Control-Allow-Methods: POST
Access-Control-Allow-Headers: Content-Type, Authorization
public void SetRequestHeader(string name, string value); 
         */
        
        /*
         * [Serializable]
public class GameData
{
    public string unique_id {get; set;}
    public int score {get; set;}
    public string game_id {get; set;}
}
         */
        
        string jsonString =
            "{\"unique_id\": \"" + instanceData.unique_id +
            "\",\n\"score\": " + instanceData.score +
            ",\n\"game_id\": \"" + instanceData.game_id +"\"}";
        Debug.Log($"**********{jsonString}");
        using (var webRequest = UnityWebRequest.Post(SEND_SCORE, jsonString))
        {
            webRequest.method = UnityWebRequest.kHttpVerbPOST;
            
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonString);
            Debug.Log($"{jsonToSend}");
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            var origin = webRequest.GetRequestHeader("Origin");
            Debug.Log($"Origin: {origin}");
            webRequest.SetRequestHeader("Content-Type","application/json");
            /*webRequest.SetRequestHeader("Accept","application/json");
            webRequest.SetRequestHeader("Access-Control-Allow-Credentials","true");
            webRequest.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time," +
                                                                        "Access-Control-Request-Method, Access-Control-Request-Headers, Origin" );
            webRequest.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            webRequest.SetRequestHeader("Access-Control-Allow-Origin", "*");*/
            
            
            Debug.Log($"Progress: {webRequest.uploadProgress}");
            
            yield return webRequest.SendWebRequest();
            Debug.Log($"Request {webRequest.url}");
            Debug.Log($"Request {webRequest.result}");
            Debug.Log($"Request {webRequest.responseCode}");
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Failed to post score: {webRequest.error}");
                if (onFail != null)
                {
                    onFail(webRequest.error);
                }
            }
            else
            {
                Debug.Log("Form upload complete!");
                if (onSuccessful != null)
                {
                    onSuccessful(webRequest.downloadHandler.text);
                }
            }
        }
    }
}

[Serializable]
public class GameData
{
    public string unique_id {get; set;}
    public int score {get; set;}
    public string game_id {get; set;}
}
