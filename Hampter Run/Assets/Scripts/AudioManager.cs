using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgm;
    public AudioSource sfx;
    public AudioClip[] bgmClips;
    public AudioClip[] sfxClips; //0 = button click, 1 = break vase, 2 = collect star, 3 = go to mirror
    public bool isMainMenu;

    void Awake() => instance = this;

    private void Start()
    {
        if (isMainMenu)
        {
            MainMenuBGM();
        }
        else
        {
            GameBGM();
        }
    }

    public void ButtonClick()
    {
        sfx.volume = 0.1f;
        sfx.PlayOneShot(sfxClips[0]);
    }
    public void BreakVase()
    {
        sfx.volume = 0.1f;
        sfx.PlayOneShot(sfxClips[1]);
    }
    public void CollectStar()
    {
        sfx.volume = 0.1f;
        sfx.PlayOneShot(sfxClips[2]);
    }
    public void FinishLevel()
    {
        sfx.volume = 0.1f;
        sfx.PlayOneShot(sfxClips[3]);
    }

    public void MainMenuBGM()
    {
        bgm.clip = bgmClips[0];
        bgm.volume = 0.5f;
        bgm.Play();
    }

    public void GameBGM()
    {
        bgm.clip = bgmClips[1];
        bgm.volume = 0.15f;
        bgm.Play();
    }

    /*public void MusicVolume()
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
    }*/
}
