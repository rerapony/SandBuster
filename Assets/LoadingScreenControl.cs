using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreenControl : MonoBehaviour
{
    public Slider slider;

    AsyncOperation async;

    void Awake()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        Debug.Log("Hey");
        async = SceneManager.LoadSceneAsync("game");
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            Debug.Log("Progress " + async.progress);
            slider.value = async.progress;
            if (async.progress > 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
