using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    private PlayerProgress playerProgress;

    string dataFileName = "data.json";

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetCurrentRoundData();

        LoadGameData();

//        SceneManager.LoadScene("QuizMenu");
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    // submit new player score and save
    public void SubmitNewPlayerScore(int newScore)
    {
        if (newScore > GetHighestScore()) // player progress highest ..
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }

    // get player progress highest score
    int GetHighestScore()
    {
        return playerProgress.highestScore;
    }


    void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highestScore"))
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
    }

    void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", GetHighestScore());
    }

    void LoadGameData() // interact with json data file
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, dataFileName);

        if (File.Exists(filePath))
        {
//            string jsonData = File.ReadAllText(filePath);

//            RoundData loadedData = JsonUtility.FromJson(jsonData);

//            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.Log("Cannot load data");
        }
    }
}
