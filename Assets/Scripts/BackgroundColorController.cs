using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    // [SerializeField]
    // private Material mainColor;
    [SerializeField]
    private Material[] colorsArray;
    public static BackgroundColorController Instance = null; 
    [SerializeField]
    private Camera mainCamera;

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
    }

    private Material ChouseColor()
    {
        return colorsArray[Random.Range(0,colorsArray.Length)];
    }

    public void SetColorInCamera()
    {
        mainCamera.GetComponent<Skybox>().material = ChouseColor();
    }

    // public void ResetToMainColor()
    // {
    //     mainCamera.GetComponent<Skybox>().material = mainColor;
    // }
}
