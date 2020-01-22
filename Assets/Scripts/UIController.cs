using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject knifePrefab;
    [SerializeField]
    private Transform  knifeParent;
    [SerializeField]
    private GameObject goalPrefab;
    [SerializeField]
    private Transform  goalParent;
    private Color colorForDisableGoal = new Color(0.1698113f,0.1481844f,0.1481844f,1f);

    public void NewKnifeInstantiate() 
    {
        Instantiate(knifePrefab,knifeParent);
    }

    public void NewGoalInstantiate(int count) 
    {
       for(int i = 0; i < count; i++) 
       {
           Instantiate(goalPrefab,goalParent);
       }
    }

    public void ChangeColorForDisabledGoal(int index) 
    {
        goalParent.transform.GetChild(index).GetComponent<SpriteRenderer>().color = colorForDisableGoal;
    }

}

