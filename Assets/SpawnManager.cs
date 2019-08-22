using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnManager : MonoBehaviour
{
    
    public float TIME = 1f;
    private float initialTIME;
    private float SpawnTime;
    public GameObject[] Slots;
    public SpawnPoint[] spawners = new SpawnPoint[9];
    public GameObject[] prefabs = new GameObject[2];
    public const int failNumber = 9;
    public float[] percents = new float[2];
    private GameObject NewSpawnedObject;
    private int a;
    public int SpeedUpPercent = 100;
    public int SlowDownPercent = 30;
    public int occupiedPoints = 0;


    private void Start()

    {
        SpawnTime = TIME;
        initialTIME = TIME;
        for (int i = 0; i < Slots.Length; i++)
        {
            spawners[i] = Slots[i].GetComponent<SpawnPoint>();
        }
        StartCoroutine("ChangeSpeed");
    }

    void FixedUpdate()
    {
        occupiedPoints = 0;
        SpawnTime -= Time.deltaTime;
        int index = Random.Range(0, spawners.Length);
        if (spawners[index].isOccupied == false && SpawnTime < 0)
        {
            float compareValue = Random.value;
            float temp = 0;
            for (int i = 0; i < percents.Length; i++)
            {
                if (compareValue < percents[i] + temp && compareValue >= temp)
                {
                    NewSpawnedObject = Instantiate(prefabs[i], spawners[index].transform.position, spawners[index].transform.rotation);
                    var NewMouseDissapear = NewSpawnedObject.GetComponent<MouseDissapear>();
                    NewMouseDissapear.point = spawners[index];
                    spawners[index].isOccupied = true;
                    break;
                }
                else
                {
                    temp += percents[i];
                }

            }
            SpawnTime = TIME;
        }

        for (int i = 0; i < Slots.Length; i++)
        {
            if (spawners[i].isOccupied == true)
            {
                occupiedPoints += 1;
            }
        }
        if (occupiedPoints >= failNumber)
        {
            Lose();
        }

    }

    IEnumerator ChangeSpeed()
    {

        yield return ChangeSpeedTo(SpeedUpPercent, SpeedUpPercent * 2);
        for (int i = 2; i < 10; i += 1)
        {
            yield return ChangeSpeedTo(SpeedUpPercent * i, SpeedUpPercent * i - SlowDownPercent);
            yield return ChangeSpeedTo(SpeedUpPercent * i - SlowDownPercent, SpeedUpPercent * (i + 1));
        }

    }

    IEnumerator ChangeSpeedTo(int startFrom, int finishWith)
    {
        if (finishWith >= startFrom)
        {
            a = 1;
        }
        else
        {
            a = -1;
        }

        for (int i = startFrom; i != finishWith; i += a)
        {

            yield return new WaitForSeconds(1);
            TIME = initialTIME * 100 / i;
        }
    }


    public void Lose()
    {
        this.StartCoroutine("LoseTimer");
    }

    IEnumerator LoseTimer()
    { 
        yield return new WaitForSeconds(0.3f);
        Debug.Log("YOU LOST");
        OnTimeSatan.isSatan = false;
        SceneManager.LoadScene("LoseScreen");
    }
}
