using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard Instance = null;
    [SerializeField]
    private Text scoreboard;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text bestStagesText;
    [SerializeField]
    private Text bestLlvsText;
    private int currentPlayerScore = 0;
    private int bestPlayerScore;
    private int maxStagesComplete;
    private int currenStagesComplete = 0;
    private int maxLvlComplete;
    private int currentLvlComplete = 0;

    private void Awake () 
    {
        if (Instance == null) 
        { 
	        Instance = this; 

	    } else if(Instance == this)
        { 
	        Destroy(gameObject); 
	    }
        InitBestPlayerScore();
        InitMaxStages();
        InitMaxLvl();
    }

    public void SetScoreInText()
    {
        scoreboard.text = currentPlayerScore.ToString();
    }

    public void IncrementPlayerScore()
    {
        currentPlayerScore = currentPlayerScore + 1;
    }

    public void ResetScoreAfterLose()
    {
        currentPlayerScore = 0;
        currenStagesComplete = 0;
        currentLvlComplete = 0;
    }

    private void InitBestPlayerScore()
    {
        if(PlayerPrefs.HasKey("BestScore"))
        {
            bestPlayerScore = PlayerPrefs.GetInt("BestScore");
        } else {
            bestPlayerScore = 0;
        }
    }

    public void SaveBestScore()
    {
        if(currentPlayerScore > bestPlayerScore)
        {
            PlayerPrefs.SetInt("BestScore",currentPlayerScore);
        }
    }

    public void SetBestScoreInText()
    {
        bestScoreText.text = bestPlayerScore.ToString();
    }

    private void InitMaxStages()
    {
        if(PlayerPrefs.HasKey("BestStages"))
        {
            maxStagesComplete = PlayerPrefs.GetInt("BestStages");
        } else {
            maxStagesComplete = 0;
        }
    }

    public void SaveBestStages()
    {
        if(currenStagesComplete > maxStagesComplete)
        {
            PlayerPrefs.SetInt("BestStages",currenStagesComplete-1);
        }
    }

    public void SaveCurrentStagesComplete()
    {
        currenStagesComplete++;
    }

    public void SetBestStageInText()
    {
        bestStagesText.text = maxStagesComplete.ToString();
    }

    private void InitMaxLvl()
    {
        if(PlayerPrefs.HasKey("BestLvl"))
        {
            maxLvlComplete = PlayerPrefs.GetInt("BestLvl");
        } else {
            maxLvlComplete = 0;
        }
    }

    public void SaveBestLvl()
    {
        if(currentLvlComplete > maxLvlComplete)
        {
            PlayerPrefs.SetInt("BestLvl",currentLvlComplete);
        }
    }

    public void SaveCurrentLvlsComplete()
    {
        currentLvlComplete++;
    }

    public void SetBestLvlInText()
    {
        bestLlvsText.text = maxLvlComplete.ToString();
    }
}
