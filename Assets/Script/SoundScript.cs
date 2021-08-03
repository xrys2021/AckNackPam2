using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    private Music music;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public bool mute;

    void Start () {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIconAndVolume();
    }
    
    void Update () {

    }

    public void PauseMusic()
    {
        music.ToggleSound(); //updated our player prefs.
        UpdateIconAndVolume();
    }

    void UpdateIconAndVolume()
    {
        if (PlayerPrefs.GetInt( "Muted", 0) == 0)
        { 
            mute=true;
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            mute=false;
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }


}
