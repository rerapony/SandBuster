using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkScript : BonusScript
{
    private int temp;
    public AudioSource forkSound;
    //private SpawnManager sm;

    public override void BonusPick()
    {
        forkSound.Play(0);
        var dust = GameObject.Find("BonusManager").GetComponent<BonusManager>().dust;
        var spawners = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().spawners;
        var all_obj = GameObject.FindGameObjectsWithTag("Square");
        var sandSound = GameObject.Find("BonusManager").GetComponent<AudioSource>();
        temp = Random.Range(0, 3);
        
        for (int i = 0; i < 3; i++)
        {
            foreach (GameObject obj in all_obj)
                {
                    if (obj.transform.position == spawners[i + 3*temp].transform.position)
                    {

                        Instantiate(dust, new Vector3(spawners[i + 3 * temp].transform.position.x, spawners[i + 3 * temp].transform.position.y - 1f, spawners[i + 3 * temp].transform.position.z), spawners[i + 3 * temp].transform.rotation);
                        sandSound.Play(0);
                        Destroy(obj);
                        spawners[i + 3 * temp].isOccupied = false;

                    }
                }
        }
        point.isOccupied = false;

        transform.position = Vector3.one * 9999f;
        Destroy(gameObject, forkSound.clip.length);
    }
}
