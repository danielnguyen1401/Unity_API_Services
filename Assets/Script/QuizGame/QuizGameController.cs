using UnityEngine;
using UnityEngine.UI;

public class QuizGameController : MonoBehaviour
{
    [SerializeField] DataController dataController;
    [SerializeField] Text timeRemainText;
    private RoundData currentRoundData;
    private float timeRemain;
    private bool isActive = true;

    void Start()
    {
        currentRoundData = dataController.GetCurrentRoundData();
        timeRemain = currentRoundData.limitTimeInSecond;
        timeRemain += 0.4f;
//        UpdateTimeRemain();
    }

    void Update()
    {
        if (isActive)
        {
            timeRemain -= Time.deltaTime;
            UpdateTimeRemain();

            if (timeRemain <= 0)
                EndRound();
        }
    }

    void UpdateTimeRemain()
    {
        timeRemainText.text = Mathf.Round(timeRemain).ToString();
    }

    void EndRound()
    {
        isActive = false;
    }
}
