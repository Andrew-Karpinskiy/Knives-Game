using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsController : MonoBehaviour
{
    public static PanelsController Instance = null;
    [SerializeField]
    private GameObject mainPanel; 
    [SerializeField]
    private GameObject settingsPanel;
   
   
    


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


    public void OpenSettingsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenMainPanel()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

}
