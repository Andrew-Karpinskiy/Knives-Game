using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard Instance = null;
    [SerializeField]
    private Text scoreboard;
    private int currentPlayerScore = 0;
    private int bestPlayerScore;

    private void Awake () 
    {
        if (Instance == null) 
        { 
	        Instance = this; 

	    } else if(Instance == this)
        { 
	        Destroy(gameObject); 
	    }
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
    }

    
}
