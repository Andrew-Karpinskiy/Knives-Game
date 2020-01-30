using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel; 
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private Transform panelWithGoals;
    [SerializeField]
    private GameObject menuWindow;
    [SerializeField]
    private GameObject gameWindow;
    [SerializeField]
    private GameObject goalsAndScorePanel;
    [SerializeField]
    private GameObject recordPanel;

    public static PanelsController Instance = null; 

    private void Awake () 
    {
        if (Instance == null) 
        { 
	        Instance = this; 

	    } else if(Instance == this)
        { 
	        Destroy(gameObject); 
	    }
        OpenMenu();
    }

    public void OpenSettingsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenMainPanelFromSettings()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OpenMainPanelFromRecords()
    {
        recordPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OpenLosePanel() 
    {
        losePanel.SetActive(true);
    }

    public void CloseLosePanel()
    {
        losePanel.SetActive(false);
    }

    public void ResetPanelsWithGoals()
    {
        foreach (Transform child in panelWithGoals)
        {
            Destroy(child.gameObject);
        }    
    }

    public void OpenRecordsPanel()
    {
        recordPanel.SetActive(true);
        ScoreBoard.Instance.SetBestScoreInText();
        ScoreBoard.Instance.SetBestStageInText();
        ScoreBoard.Instance.SetBestLvlInText();
        mainPanel.SetActive(false);
    }

    public void OpenMenu()
    {
        goalsAndScorePanel.SetActive(false);
        gameWindow.SetActive(false);
        menuWindow.SetActive(true);
    }

    public void OpenGame()
    {
        menuWindow.SetActive(false);
        losePanel.SetActive(false);
        goalsAndScorePanel.SetActive(true);
        gameWindow.SetActive(true);
    }

}
