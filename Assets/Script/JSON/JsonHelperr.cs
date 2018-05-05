using UnityEngine;

public class JsonHelperr
{
    public static T[] GotJsonArray<T>(string json)
    {
        string newJson = "{\"array\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    class Wrapper<T>
    {
        public T[] array = null;
    }
}

[System.Serializable]
public struct Post
{
    public int userId;

//    public int id;
    public string title;

    public string body;
}


[System.Serializable]
public struct Geo
{
    public string lat;
    public string lng;
}

[System.Serializable]
public struct Address
{
    public string street;
    public string suite;
    public string city;
    public string zipcode;
    public Geo geo;
}

[System.Serializable]
public struct Company
{
    public string name;
    public string catchPhrase;
    public string bs;
}

[System.Serializable]
public struct User
{
    public int id;
    public string name;

    public string username;
    public string email;
    public Address address;
    public string phone;
    public string website;
    public Company company;
}
