using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : BonusScript
{

    private int temp;
    public AudioSource bombSound;

    public override void BonusPick()
    {
        bombSound.Play(0);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().Lose();
        point.isOccupied = false;
    }
}

        
