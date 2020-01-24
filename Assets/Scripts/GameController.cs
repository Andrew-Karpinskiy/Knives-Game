using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get;private set;}
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject gamePanel;
    private int availableKnives;
    private bool isPlayerLose = false;
    
    private void Awake() 
    {
       Instance = this;
       availableKnives = SetAvailableKnivesRandomly(); 
       GetComponent<UIController>().NewGoalInstantiate(availableKnives);
       GetComponent<ScoreBoard>().SaveScoreBeforeNewRound();
       GetComponent<ScoreBoard>().SetScoreInText();
    }

    private void FixedUpdate()
    {
        StartNewGameLevel();
    }

    private int SetAvailableKnivesRandomly() 
    {
       return Random.Range(5,11);
    }

    public void OnSuccessfulHit()
	{
		availableKnives--;
        GetComponent<ScoreBoard>().IncrementPlayerScore();
        GetComponent<ScoreBoard>().SetScoreInText();
        GetComponent<UIController>().ChangeColorForDisabledGoal(availableKnives);
        if(availableKnives > 0 && !isPlayerLose) 
        {
            GetComponent<UIController>().NewKnifeInstantiate();
        }
	}

    public void StopTheGame() 
    {
        isPlayerLose = true;
        losePanel.SetActive(true);
    }

    public void RestartTheGame()
    {
        GetComponent<ScoreBoard>().ResetScoreAfterLose();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StartNewGameLevel() 
    {
        if(availableKnives == 0 && isPlayerLose == false)
        {
            GetComponent<ScoreBoard>().SaveCurrentScoreInCache();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    
    }

}
