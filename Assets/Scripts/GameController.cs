using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject knifePrefab;
    [SerializeField]
    private Transform  knifeParent;
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private Transform  goalParent;
    private int availableKnives;
    private Color colorForDisableGoal = new Color(0.1698113f,0.1481844f,0.1481844f,1f);
    
    private void Awake() 
    {
       availableKnives = SetAvailableKnivesRandomly(); 
       NewGoalInstantiate();
    }
   
    private void OnCollisionEnter2D(Collision2D other)
	{
		availableKnives--;
        ChangeColorForDisabledGoal();
        if(availableKnives > 0 ) 
        {
            NewKnifeInstantiate();
        }
	}

   private int SetAvailableKnivesRandomly() 
   {
       return Random.Range(5,11);
   }

   private void NewKnifeInstantiate() 
   {
        Instantiate(knifePrefab,knifeParent);
   }

   private void NewGoalInstantiate() 
   {
       for(int i = 0; i < availableKnives; i++) 
       {
           Instantiate(goalPrefab,goalParent);
       }
   }

   private void ChangeColorForDisabledGoal() 
   {
        goalParent.transform.GetChild(availableKnives).GetComponent<SpriteRenderer>().color = colorForDisableGoal;
   }
}