using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HandlingArrays : MonoBehaviour
{
    public User[] users;

    void Start()
    {
        StartCoroutine(LoadUSer());
    }

    IEnumerator LoadUSer()
    {
        string url = API.baseURL + "/users";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                users = JsonHelperr.GotJsonArray<User>(jsonResult);
            }
        }
    }
}
