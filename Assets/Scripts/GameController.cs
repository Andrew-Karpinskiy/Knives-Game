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
   
    private void Awake() 
    {
       availableKnives = SetAvailableKnivesRandomly(); 
       NewGoalInstantiate();
    }
   
    private void OnCollisionEnter2D(Collision2D other)
	{
		availableKnives--;
        if(availableKnives > 0 ) 
        {
            NewKnifeInstantiate();
        }
	}

   private int SetAvailableKnivesRandomly() 
   {
       return Random.Range(4,9);
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
}
