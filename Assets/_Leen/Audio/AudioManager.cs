using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // to access the AudioManager from other scripts
    public static AudioManager instance;
        
    [Header("Audio")]
    public Sound[] musicSounds;
    public Sound[] sfxSounds;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        // singleton pattern to ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 

    private void Start()
    {
        //play background music at the start
        PlayMusic("BGM");
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicSounds, sound => sound.name == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music sound not found: " + name);
        }
    }

    public void playSFX(string name)
    {
        Sound s = System.Array.Find(sfxSounds, sound => sound.name == name);
        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
        else
        {
            Debug.LogWarning("SFX sound not found: " + name);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        Debug.Log("Music toggled. Mute is now: " + musicSource.mute);
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        Debug.Log("SFX toggled. Mute is now: " + sfxSource.mute);
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        Debug.Log("Music volume set to: " + volume);
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        Debug.Log("SFX volume set to: " + volume);
    }

}
