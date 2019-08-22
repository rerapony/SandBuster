using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[2];
    public bool isPaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (isPaused == true)
        {
            GetComponent<Image>().sprite = sprites[1];
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            GetComponent<Image>().sprite = sprites[0];
            Time.timeScale = 1;
            pauseMenu.SetActive(false);

        }
    }

    public void pressPause()
    {
        isPaused = !isPaused;
    }
}
