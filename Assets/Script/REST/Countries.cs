using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Countries : MonoBehaviour
{
    Dropdown ddlCountries;
    [SerializeField] Text countryValueText;

    void Start()
    {
        ddlCountries = GetComponent<Dropdown>();
        ddlCountries.ClearOptions();
        StartCoroutine(GetCountries());
    }


    IEnumerator GetCountries()
    {
        string getCountriesUrl = "https://restcountries.eu/rest/v2/all";
        UnityWebRequest www = UnityWebRequest.Get(getCountriesUrl);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.isDone)
            {
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
//                Debug.Log(jsonResult);
                Country[] countries = JsonHelper.GetJsonArray<Country>(jsonResult);

                ddlCountries.options.AddRange(countries.OrderBy(p => p.name)
                    .Select(x => new Dropdown.OptionData() {text = x.nativeName}).ToList());

                ddlCountries.value = 0;
            }
        }
    }

    public void OnValueChange() // show the country's name by drop down
    {
        countryValueText.text = ddlCountries.options[ddlCountries.value].text;
    }

    void Update()
    {
    }
}
