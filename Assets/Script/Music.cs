using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    static Music instance = null;
[SerializeField] private bool mute;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0) {
            PlayerPrefs.SetInt("Muted", 1);
            mute=true;
            //AudioListener.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            mute=false;
            //AudioListener.volume = 0;
        }
    }

}   
