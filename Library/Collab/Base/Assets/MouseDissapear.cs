﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDissapear : MonoBehaviour
{
    public SpawnPoint point;
    private SpawnManager sm;
    private GameObject satan;
    public int scoreValue = 2;
    public int maxCounter = 2;
    private int counter;
    private AudioSource sandSound;
    private BonusManager bm;
    //private Animator animator;
    public bool isBroken = false;
    public Animation broken_animation;

    private void Start()
    {
        //sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        satan = GameObject.Find("satan");
        sandSound = GameObject.Find("SpawnManager").GetComponent<AudioSource>();
        //animator = gameObject.GetComponent<Animator>();
        counter = 0;
        bm = GameObject.Find("BonusManager").GetComponent<BonusManager>();

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null && OnTimeSatan.isSatan == false)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    counter += 1;
                    if (counter >= maxCounter)
                    {
                        sandSound.Play(0);
                        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().squareNumber -= 1;
                        ScoreManager.score += scoreValue;
                        Destroy(gameObject);
                        point.isOccupied = false;
                        //animator.SetBool("isBroken", true);
                        bm.getBonus(point);
                    }
                }
            }
            else if (hit.collider != null && OnTimeSatan.isSatan == true)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    SpawnManager.Lose();
                }
            }
        }
    }

}


    