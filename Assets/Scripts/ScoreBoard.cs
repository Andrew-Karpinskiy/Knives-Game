using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private Text scoreboard;
    private int currentPlayerScore = 0;
    private int bestPlayerScore;

    public void SetScoreInText()
    {
        scoreboard.text = currentPlayerScore.ToString();
    }

    public void SaveCurrentScoreInCache()
    {
        PlayerPrefs.SetInt("CurrentScore",currentPlayerScore);
    }

    public int GetCurrentPlayerScoreFromCache()
    {
        return PlayerPrefs.GetInt("CurrentScore");
    }

    public void IncrementPlayerScore()
    {
        currentPlayerScore = currentPlayerScore + 10;
    }

    public void ResetScoreAfterLose()
    {
        PlayerPrefs.SetInt("CurrentScore",0);
    }

    public void SaveScoreBeforeNewRound()
    {
        currentPlayerScore = GetCurrentPlayerScoreFromCache();
    }
}
