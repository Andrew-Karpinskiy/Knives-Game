using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance = null; 
    private AudioSource hitSound;
    [SerializeField]
    private AudioSource mainSound;
    public bool isSoundOn;
    public bool isMusicOn;
    public bool isVibrationOn;

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
        hitSound = GetComponent<AudioSource>();
        SetSettings();
    }

    private void Start()
    {
        PlayMainMusic();
    }

    private void FixedUpdate()
    {
        ReplayMainMusic();
    }

    public void PlayHitSound()
    {
        if(isSoundOn == true)
        {
            hitSound.Play();
        }
    }

    public void PlayMainMusic()
    {
        if( isMusicOn == true)
        {
            mainSound.Play();
        }
    }

    public void ReplayMainMusic()
    {
        if(!mainSound.isPlaying)
        {
            PlayMainMusic();
        }
    }

    public void StopMainMusic()
    {
        mainSound.Stop();
    }

    public void SaveSoundSettingsInCache(bool bl)
    {
        isSoundOn = bl;
        PlayerPrefs.SetString("Sound",bl.ToString());
    }

    public bool GetSoundSettingsFromCache()
    {
        bool result = (PlayerPrefs.GetString("Sound") == "True");
        return result;
    }

    public void SaveMusicSettingsInCache(bool bl)
    {
        isMusicOn = bl;
        PlayerPrefs.SetString("Music",bl.ToString());
    }

    public bool GetMusicSettingsFromCache()
    {
        bool result = (PlayerPrefs.GetString("Music") == "True");
        return result;
    }

    private void SetSettings()
    {
        if(PlayerPrefs.HasKey("Music"))
        {
            isMusicOn = GetMusicSettingsFromCache();
        } else {
            isMusicOn = true;
        }

        if(PlayerPrefs.HasKey("Sound"))
        {
            isSoundOn = GetSoundSettingsFromCache();
        } else {
            isSoundOn = true;
        }

        if(PlayerPrefs.HasKey("Vibration"))
        {
            isVibrationOn = GetVibrationSettingsFromCache();
        } else {
            isVibrationOn = true;
        }
    }

    public void PlayVibration()
    {
        if(isVibrationOn == true)
        {
            Handheld.Vibrate();
        }
    }

     public void SaveVibrationSettingsInCache(bool bl)
    {
        isVibrationOn = bl;
        PlayerPrefs.SetString("Vibration",bl.ToString());
    }

    public bool GetVibrationSettingsFromCache()
    {
        bool result = (PlayerPrefs.GetString("Vibration") == "True");
        return result;
    }
}
