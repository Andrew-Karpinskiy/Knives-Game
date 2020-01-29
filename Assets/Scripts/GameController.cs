using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController Instance {get;private set;}
    private int availableKnives;
    private bool isPlayerLose = false;
    
    private void Awake() 
    {
       Instance = this;
    }

    private void FixedUpdate()
    {
        IfPlayerWin();
    }

    private int SetAvailableKnivesRandomly() 
    {
       return Random.Range(5,10);
    }

    public void OnSuccessfulHit()
	{
		availableKnives--;
        ScoreBoard.Instance.IncrementPlayerScore();
        ScoreBoard.Instance.SetScoreInText();
        GetComponent<InstantiateManager>().ChangeColorForDisabledGoal(availableKnives);
        if(availableKnives > 0 && !isPlayerLose) 
        {
            GetComponent<InstantiateManager>().NewKnifeInstantiate();
        }
	}

    public void StopTheGame() 
    {
       PanelsController.Instance.OpenLosePanel();
       ScoreBoard.Instance.SaveBestScore();
      
    }

    public void IfPlayerLose()
    {
        ScoreBoard.Instance.ResetScoreAfterLose();
        ResetCurrentLevel();
        PanelsController.Instance.CloseLosePanel();
        LvlController.Instance.RestartGame();
    }

    private void ResetCurrentLevel()
    {
        DestroyOldLevel();
        PanelsController.Instance.ResetPanelsWithGoals();
        StartNewGameLevel();
        
    }

    public void StartNewGameLevel() 
    {
       availableKnives = SetAvailableKnivesRandomly();
       GetComponent<InstantiateManager>().NewLevelInstantiate(); 
       GetComponent<InstantiateManager>().NewGoalInstantiate(availableKnives);
       ScoreBoard.Instance.SetScoreInText();
    }

    private void IfPlayerWin()
    {
        if(availableKnives == 0 && isPlayerLose == false)
        {
           ResetCurrentLevel();
           LvlController.Instance.IncrementCurrentStage();
           LvlController.Instance.SetCurrentStageInText();
           LvlController.Instance.SetCurrentLvlInText();
           ScoreBoard.Instance.SaveBestStages();
        }
    }

    private void DestroyOldLevel()
    {
        Destroy(GameObject.Find("GamePanel(Clone)"));
    }

    
}
