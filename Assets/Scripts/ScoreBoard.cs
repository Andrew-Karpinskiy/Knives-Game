using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private Text scoreboard;
    private int playerScore = 0;

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void SetScoreInText()
    {
        scoreboard.text =playerScore.ToString();
    }

    public void SaveScoreInCache()
    {
        PlayerPrefs.SetInt("UserScore",playerScore);
    }

    public int GetPlayerScoreFromCache()
    {
        return PlayerPrefs.GetInt("UserScore");
    }

    public void IncrementPlayerScore()
    {
        playerScore = playerScore + 10;
    }

    public void ResetScoreAfterLose()
    {
        PlayerPrefs.SetInt("UserScore",0);
    }

    public void AfterWin()
    {
        playerScore = GetPlayerScoreFromCache();
    }


}
