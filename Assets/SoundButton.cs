using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    public static bool isSoundOff = false;
    public AudioListener listener;
    public float volume;


    private void Start()
    {
        listener = GameObject.FindWithTag("MainCamera").GetComponent<AudioListener>();
    }

    private void Update()
    {
        if (isSoundOff==true)
        {
            GetComponent<Image>().sprite = sprites[1];
            AudioListener.pause = true;
        }
        else
        {
            GetComponent<Image>().sprite = sprites[0];
            AudioListener.pause = false;
        }
    }

    public void SoundPressed()
    {

        isSoundOff = !isSoundOff;
    }
}