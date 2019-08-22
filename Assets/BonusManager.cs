using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public GameObject[] bonuses = new GameObject[2];
    public float[] bonus_percents = new float[2];
    //public SpawnPoint point;
    //public GameObject NewBonus;
    public float bonusEventPercent = 0.9f;
    public float BonusTime = 1f;

    public GameObject dust;
   

    // Update is called once per frame
    public void getBonus(SpawnPoint point)
    {
        float value = Random.value;
        if (value > (1 - bonusEventPercent))
        {
            float compareValue = Random.value;
            //Debug.Log(compareValue);
            float temp = 0;
            for (int i = 0; i < bonus_percents.Length; i++)
            {
                if (compareValue < bonus_percents[i] + temp && compareValue >= temp)
                {

                    var NewBonus = Instantiate(bonuses[i], new Vector3(point.transform.position.x, point.transform.position.y, point.transform.position.z-2f), point.transform.rotation);
                    point.isOccupied = true;
                    NewBonus.GetComponent<BonusScript>().BonusCore(point, BonusTime);

                   
                    break;
                   
                }
                else
                {
                    temp += bonus_percents[i];
                }
            }

        }
    }

   
    
}