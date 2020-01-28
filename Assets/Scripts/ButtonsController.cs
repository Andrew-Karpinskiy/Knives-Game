using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    private Button musicOn,musicOff,soundOn,soundOff;
    
    private void Start()
    {
        DisplayMusicButtons();
    }

    public void StartGameButton() 
    {
        PanelsController.Instance.OpenGame();
    }

    public void RestartGameButton() 
    {
       GameController.Instance.IfPlayerLose();
    }

    public void SettingsButton()
    {
        PanelsController.Instance.OpenSettingsPanel();
    }

    public void BackToMainButton()
    {
        PanelsController.Instance.OpenMainPanel();
    }

    //КНОПКИ
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


    //ОТОБРАЖЕНИЕ КНОПОК 
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

    private void DisplayMusicButtons()
    {
        if(SoundController.Instance.GetMusicSettingsFromCache() == true)
        {
            SetActiveToMusicOnButton(true);
            SetActiveToMusicOffButton(false);
        } else {
            SetActiveToMusicOnButton(false);
            SetActiveToMusicOffButton(true);
        }

        if(SoundController.Instance.GetSoundSettingsFromCache() == true)
        {
            SetActiveToSoundOnButton(true);
            SetActiveToSoundOffButton(false);
        } else {
            SetActiveToSoundOnButton(false);
            SetActiveToSoundOffButton(true);
        }
        
    } 
}
