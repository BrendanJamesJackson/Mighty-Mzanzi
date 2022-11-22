using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class PenroseAPIBridge
{
    public const string CHECK_USER = "https://c5ir2jqn75.execute-api.eu-west-2.amazonaws.com/mzansi-api/checkUser?unique-id=";
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
        WWWForm form = new WWWForm();
        form.AddField("unique_id", UniqueId);
        form.AddField("score", score);
        form.AddField("game_id", GameId);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(SEND_SCORE, form))
        {
            yield return webRequest.SendWebRequest();

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
