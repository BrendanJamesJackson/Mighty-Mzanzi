using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenroseAPIManager : MonoBehaviour
{   
    public void TryCheckUsername(Action<string> onSuccessful, Action<string> onFail)
    {
        StartCoroutine(PenroseAPIBridge.CheckUser(onSuccessful, onFail));
    }

    public void TryPostScore(int score, Action<string> onSuccessful, Action<string> onFail)
    {
        StartCoroutine(PenroseAPIBridge.PostScore(score, onSuccessful, onFail));
    }
}
