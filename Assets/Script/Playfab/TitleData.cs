using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class TitleData : MonoBehaviour
{
    void Start()
    {
//        GetTitleInternalData();
    }

    void SetTitleInternalData()
    {
    }

    void GetTitleInternalData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
            result =>
            {
                if (result.Data != null || !result.Data.ContainsKey("Name"))
                    Debug.Log("No name");
                else
                    Debug.Log(result.Data["Name"]);
            },
            error => { Debug.Log("Error: " + error.GenerateErrorReport()); }
        );
    }
}
