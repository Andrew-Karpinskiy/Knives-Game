using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    private Button musicOn,musicOff,soundOn,soundOff;  //play,settings,restart,backToMain,soundOn,soundOff;
    public static ButtonsController Instance = null;

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

    public void StartGameButton() 
    {
        SceneManager.LoadScene("Game");
        PlayerPrefs.SetInt("CurrentScore",0);
    }

    public void RestartGameButton() 
    {
       GameController.Instance.RestartTheGame();
    }

    public void SettingsButton()
    {
        PanelsController.Instance.OpenSettingsPanel();
    }

    public void BackToMainButton()
    {
        PanelsController.Instance.OpenMainPanel();
    }

   
}
