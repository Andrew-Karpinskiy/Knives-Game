using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance = null; 
    private AudioSource hitSound;
    [SerializeField]
    private AudioSource mainSound;
    public bool isSoundOn = true;
    public bool isMusicOn = true;

    private void Awake () 
    {
        hitSound = GetComponent<AudioSource>();
        //SetSettings();
        if (Instance == null) 
        { 
	        Instance = this; 

	    } else if(Instance == this)
        { 
	        Destroy(gameObject); 
	    }
        DontDestroyOnLoad(gameObject);
        PlayMainMusic();
    }

    private void Update()
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
        bool result = (PlayerPrefs.GetString("Sound") == "true");
        return result;
    }

    public void SaveMusicSettingsInCache(bool bl)
    {
        isMusicOn = bl;
        PlayerPrefs.SetString("Music",bl.ToString());
    }

    public bool GetMusicSettingsFromCache()
    {
        bool result = (PlayerPrefs.GetString("Music") == "true");
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
            isMusicOn = true;
        }
    }
}
