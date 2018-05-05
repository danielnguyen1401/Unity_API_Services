using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ExportingData : MonoBehaviour
{
    public Post post;

    void Start()
    {
        StartCoroutine(PostData());
    }

    IEnumerator PostData()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();

        headers.Add("Contend-Type", "appliction/json");

        byte[] postData = Encoding.ASCII.GetBytes(JsonUtility.ToJson(post));
        WWW www = new WWW(API.baseURL + "/posts", postData, headers);

        yield return www;

        Debug.Log(www.text);
        post = JsonUtility.FromJson<Post>(www.text);

    }
}
