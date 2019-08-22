using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class storyManager : MonoBehaviour
{
    public Sprite[] frames;
    int number = 1;
    
    // Update is called once per frame
    void Update()
    {
        if (number>5)
        {
            number = 0;
            SceneManager.LoadScene("main_menu");

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (number < frames.Length)
            {
                GetComponent<SpriteRenderer>().sprite = frames[number];
            }
            number++;

        }
    }
}
