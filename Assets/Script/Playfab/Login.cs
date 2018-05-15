using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class Login : MonoBehaviour
{
    void Start()
    {
        PlayFabSettings.TitleId = "1592";
        var request = new LoginWithCustomIDRequest {CustomId = "Started", CreateAccount = true};

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
//        var request = new LoginWithEmailAddressRequest("email", "12", "12");
//        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("Error: " + error.GenerateErrorReport());
    }

    void OnLoginSuccess(LoginResult loginResult)
    {
        Debug.Log("Success");
//        Debug.Log(loginResult.LastLoginTime);
    }
}
