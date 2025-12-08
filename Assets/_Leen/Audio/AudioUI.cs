using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public GameObject muteMusicIcon;
    public GameObject muteSFXIcon;

    private void Start()
    {
        musicSlider.value = AudioManager.instance.musicSource.volume;
        sfxSlider.value = AudioManager.instance.sfxSource.volume;

        UpdateIcons();
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
        UpdateIcons();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
        UpdateIcons();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }

    private void UpdateIcons()
    {
        if (AudioManager.instance.musicSource.mute == true)
        {
            muteMusicIcon.SetActive(true);
        }
        else
        { 
            muteMusicIcon.SetActive(false);        
        }

        if (AudioManager.instance.sfxSource.mute == true)
        {
            muteSFXIcon.SetActive(true);
        }
        else
        {
            muteSFXIcon.SetActive(false);
        }

    }

}
