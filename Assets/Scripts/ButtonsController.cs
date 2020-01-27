using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    private Button musicOn,musicOff,soundOn,soundOff;  //play,settings,restart,backToMain,soundOn,soundOff;
    

    public void StartGameButton() 
    {
        PanelsController.Instance.OpenGame();
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
