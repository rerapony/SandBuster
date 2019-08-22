using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowelScript : BonusScript
{
    private List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private int temp;
    public AudioSource bombSound;

    public override void BonusPick()
    {
        bombSound.Play(0);
        var dust = GameObject.Find("BonusManager").GetComponent<BonusManager>().dust;
        var spawners = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().spawners;
        var all_obj = GameObject.FindGameObjectsWithTag("Square");
        var sandSound = GameObject.Find("BonusManager").GetComponent<AudioSource>();
        for (int i = 0; i < 4; i++)
        {
            temp = Random.Range(0, numbers.Count);
            foreach (GameObject obj in all_obj)
            {
                if (obj.transform.position == spawners[numbers[temp]].transform.position)
                {
                    Instantiate(dust, new Vector3(spawners[numbers[temp]].transform.position.x, spawners[numbers[temp]].transform.position.y - 1f, spawners[numbers[temp]].transform.position.z), spawners[numbers[temp]].transform.rotation);
                    sandSound.Play(0);
                    Destroy(obj);
                    spawners[numbers[temp]].isOccupied = false;
                }
            }
            numbers.RemoveAt(temp);
        }

        point.isOccupied = false;
        transform.position = Vector3.one * 9999f;
        Destroy(gameObject, bombSound.clip.length);
    }
    
}
        
