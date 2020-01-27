using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        CheangeLevel();
    }

    private int SetAvailableKnivesRandomly() 
    {
       return Random.Range(5,11);
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
    }

    public void RestartTheGame()
    {
        ScoreBoard.Instance.ResetScoreAfterLose();
        ResetCurrentLevel();
        PanelsController.Instance.CloseLosePanel();
        DestroyTrash();
    }

    public void StartNewGameLevel() 
    {
       availableKnives = SetAvailableKnivesRandomly();
       GetComponent<InstantiateManager>().NewLevelInstantiate(); 
       GetComponent<InstantiateManager>().NewGoalInstantiate(availableKnives);
       ScoreBoard.Instance.SetScoreInText();
    }

    private void CheangeLevel()
    {
        if(availableKnives == 0 && isPlayerLose == false)
        {
           ResetCurrentLevel();
        }
    }

    private void ResetCurrentLevel()
    {
        DeleteOldLevel();
        PanelsController.Instance.ResetPanelsWithGoals();
        StartNewGameLevel();
        DestroyTrash();
    }

    private void DeleteOldLevel()
    {
        Destroy(GameObject.Find("GamePanel(Clone)"));
    }

    private void DestroyTrash()
    {
        Destroy(GameObject.Find("Knife(Clone)"));
    }

}
