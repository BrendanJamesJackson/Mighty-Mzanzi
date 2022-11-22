using UnityEngine;

[System.Serializable]
public class CheckUserResponse
{
    public bool status;
    public int status_code;
    public string message;

    public override string ToString()
    {
        return $"Status: {status}, Status_Code: {status_code}, Message: {message}";
    }
}


public class Startup_API_connection : MonoBehaviour
{
    public GameObject Play_button;
    public GameObject Instr_button;
    public GameObject Error_text;


    [SerializeField]
    private PenroseAPIManager penroseAPIManager;

    [SerializeField] private bool useFakeId = false;
    
#if DEVELOPMENT_BUILD
    const string FAKE_ID = "f6f56f6-1139212-d2c71d7d-e297f8-bb71";
#endif
    
    private bool isValidUser = false;

    private void Awake()
    {
        PenroseAPIBridge.GetUrlParameters();
        penroseAPIManager.TryCheckUsername(OnSuccessfulCheckUsername, onFailCheckUsername);

    }

    private void onFailCheckUsername(string obj)
    {
        isValidUser = false;
        // TODO: let the player know there are network call error
       Error_text.SetActive(true);
    }

    private void OnSuccessfulCheckUsername(string obj)
    {
        Debug.Log($"Response: {obj}");
        Debug.Log($"UseFakeID: {useFakeId}");
        if (useFakeId)
        {
#if DEVELOPMENT_BUILD
            isValidUser = PenroseAPIBridge.UniqueId == FAKE_ID;
            Debug.Log($"{PenroseAPIBridge.UniqueId} -- {FAKE_ID}");
#endif
        }
        else
        {
            Debug.Log("OnSuccessfulCheckUsername");
            var checkUserResponse = JsonUtility.FromJson<CheckUserResponse>(obj);
            Debug.Log(checkUserResponse);
            isValidUser = checkUserResponse.status;
        }
        
        if (isValidUser)
        {
            Play_button.SetActive(true);
            Instr_button.SetActive(true);
        }
        else
        {
            Error_text.SetActive(true);
        }
    }
}
