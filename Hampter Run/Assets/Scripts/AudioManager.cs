using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgm;
    public AudioSource sfx;
    public AudioClip[] bgmClips;
    public AudioClip[] sfxClips;

    void Awake() => instance = this;

    public void MusicVolume()
    {
        //0 = no music, 1 = with music
        int music = PlayerPrefs.GetInt("Music Value", 1);
        if (music == 1)
        {
            bgm.volume = 0;
            PlayerPrefs.SetInt("Music Value", 0);
        }
        else
        {
            bgm.volume = 1f;
            PlayerPrefs.SetInt("Music Value", 1);
        }
    }

    public void SoundVolume()
    {
        //0 = no sound, 1 = with sound
        int sound = PlayerPrefs.GetInt("Sound Value", 0);
        if (sound == 0)
        {
            sfx.volume = 0;
            PlayerPrefs.SetInt("Sound Value", 1);
        }
        else
        {
            sfx.volume = 1f;
            PlayerPrefs.SetInt("Sound Value", 1);
        }
    }
}
