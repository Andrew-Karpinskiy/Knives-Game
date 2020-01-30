using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    private Button musicOn,musicOff,soundOn,soundOff,vibrOn,vibrOff;
    
    private void Start()
    {
        DisplayMusicButtons();
    }

    public void StartGameButton() 
    {
        PanelsController.Instance.OpenGame();
        GameController.Instance.ResetCurrentLevel();
    }

    public void RestartGameButton() 
    {
       GameController.Instance.IfPlayerLose();
    }

    public void SettingsButton()
    {
        PanelsController.Instance.OpenSettingsPanel();
    }

    public void RecordsButton()
    {
        PanelsController.Instance.OpenRecordsPanel();
    }

    public void BackToMainFromSettingButton()
    {
        PanelsController.Instance.OpenMainPanelFromSettings();
    }

    public void BackToMainFromRecordButton()
    {
        PanelsController.Instance.OpenMainPanelFromRecords();
    }

    public void BackToMainFromGameButton()
    {
        ScoreBoard.Instance.SaveAll();
        GameController.Instance.IfPlayerBackToMain();
        PanelsController.Instance.OpenMenu();
        ScoreBoard.Instance.ResetScoreAfterLose();
        LvlController.Instance.RestartGame();
    }

    public void MusicOffButton()
    {
        SetActiveToMusicOffButton(false);
        SetActiveToMusicOnButton(true);
        SoundController.Instance.SaveMusicSettingsInCache(true);
        SoundController.Instance.PlayMainMusic();
    }

    public void MusicOnButton()
    {
        SetActiveToMusicOnButton(false);
        SetActiveToMusicOffButton(true);
        SoundController.Instance.SaveMusicSettingsInCache(false);
        SoundController.Instance.StopMainMusic();
    }

    public void SoundOffButton()
    {
        SetActiveToSoundOffButton(false);
        SetActiveToSoundOnButton(true);
        SoundController.Instance.SaveSoundSettingsInCache(true);
    }

    public void SoundOnButton()
    {
        SetActiveToSoundOnButton(false);
        SetActiveToSoundOffButton(true);
        SoundController.Instance.SaveSoundSettingsInCache(false);
    }

    public void VibrOffButton()
    {
        SetActiveToVibrOffButton(false);
        SetActiveToVibrOnButton(true);
        SoundController.Instance.SaveVibrationSettingsInCache(true);
    }

    public void VibrOnButton()
    {
        SetActiveToVibrOnButton(false);
        SetActiveToVibrOffButton(true);
        SoundController.Instance.SaveVibrationSettingsInCache(false);
    }

    private void SetActiveToMusicOnButton(bool bl)
    {
        musicOn.gameObject.SetActive(bl);
    }

    private void SetActiveToMusicOffButton(bool bl)
    {
        musicOff.gameObject.SetActive(bl);
    }

    private void SetActiveToSoundOnButton(bool bl)
    {
        soundOn.gameObject.SetActive(bl);
    }

    private void SetActiveToSoundOffButton(bool bl)
    {
        soundOff.gameObject.SetActive(bl);
    } 

    private void SetActiveToVibrOnButton(bool bl)
    {
        vibrOn.gameObject.SetActive(bl);
    }

    private void SetActiveToVibrOffButton(bool bl)
    {
        vibrOff.gameObject.SetActive(bl);
    }  

    private void DisplayMusicButtons()
    {
        if(SoundController.Instance.isMusicOn== true)
        {
            SetActiveToMusicOnButton(true);
            SetActiveToMusicOffButton(false);
        } else {
            SetActiveToMusicOnButton(false);
            SetActiveToMusicOffButton(true);
        }

        if(SoundController.Instance.isSoundOn == true)
        {
            SetActiveToSoundOnButton(true);
            SetActiveToSoundOffButton(false);
        } else {
            SetActiveToSoundOnButton(false);
            SetActiveToSoundOffButton(true);
        }

        if(SoundController.Instance.isVibrationOn == true)
        {
            SetActiveToVibrOnButton(true);
            SetActiveToVibrOffButton(false);
        } else {
            SetActiveToVibrOnButton(false);
            SetActiveToVibrOffButton(true);
        }
    } 
}
