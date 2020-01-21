using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void StartGameButton() 
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGameButton() 
    {
       GameController.Instance.RestartTheGame();
    }
}
