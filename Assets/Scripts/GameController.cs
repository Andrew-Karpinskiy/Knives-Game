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
    private int availableKnives;
    private bool isPlayerLose = false;

    private void Awake() 
    {
       Instance = this;
       availableKnives = SetAvailableKnivesRandomly(); 
       GetComponent<UIController>().NewGoalInstantiate(availableKnives);
       
    }
    
   private int SetAvailableKnivesRandomly() 
   {
       return Random.Range(5,11);
   }

    public void OnSuccessfulHit()
	{
		availableKnives--;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
