using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    public static LvlController Instance = null; 
    private int currentLvl = 1;
    private int currentStage;
    private int maxLvl = 5;
    private int maxStage;
    [SerializeField]
    private Text lvlText;
    [SerializeField]
    private Text stageText;
    private string lvlTextPattern = "LVL ";
    private string stageTextPattern = "/";

    private void Awake () 
    {
        if (Instance == null) 
        { 
	        Instance = this; 

	    } else if(Instance == this)
        { 
	        Destroy(gameObject); 
	    }
        DontDestroyOnLoad(gameObject);
        StartNewGame();
    }

    private void Update()
    {
        IfPlayerCompleteAllStage();
    }

    public void IncrementCurrentStage() 
    {
        currentStage++;        
    }

    private void IncrementCurrentLvl()
    {
        currentLvl++;
    }

    private void ResetCurrentStage()
    {
        currentStage = 1;
    }

    private void ResetCurrentLvl()
    {
        currentLvl = 1;
    }

    private void SetRandomlyStageAmount()
    {
        maxStage =  Random.Range(2,6);
    }

    public void IfPlayerCompleteAllStage()
    {
        if(currentStage > maxStage)
        {
            IncrementCurrentLvl();
            ResetCurrentStage();
            StartNewGame();
        }
    }

    public void StartNewGame()
    {
        SetRandomlyStageAmount();
        SetCurrentLvlInText();
        SetCurrentStageInText();
    }

    public void RestartGame()
    {
        ResetCurrentStage();
        ResetCurrentLvl();
        StartNewGame();
    }

    public void SetCurrentStageInText()
    {
        stageText.text = currentStage + stageTextPattern + maxStage;
    }

    public void SetCurrentLvlInText()
    {
        lvlText.text = lvlTextPattern + currentLvl;
    }

    

  


}
