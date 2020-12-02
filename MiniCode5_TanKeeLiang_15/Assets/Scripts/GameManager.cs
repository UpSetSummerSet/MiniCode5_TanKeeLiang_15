using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;

    public GameObject addEnergyPrefab;
    public GameObject minusEnergyPrefab;
    public GameObject TimerCounter;
    public GameObject PlayerCon;

    public int numberOfSpawn;
    public float levelTime;
    int AECollected = 1;
    int ESpawn = 4;

    int NumberOfSpawn = 50;
    // Start is called before the first frame update
    void Start()
    {
        if (gmInstance == null)
        {
            gmInstance = this;
        }
        //Vector3 posToSpawn = new Vector3(Random.RandomRange(-10.0f, 10.0f), 0, Random.RandomRange(-10.0f, 10.0f));
        //Instantiate(addEnergyPrefab, posToSpawn, Quaternion.identity);
        if (levelTime > 0)
        {
            for (int i = 0; i < numberOfSpawn; i++)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 0, Random.Range(-25.0f, 25.0f));

                if (Random.Range(0, 2) < 1)
                {
                    Instantiate(addEnergyPrefab, posToSpawn, Quaternion.identity);
                }
                else
                {
                    Instantiate(minusEnergyPrefab, posToSpawn, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            //print("levelTime: " + levelTime.ToString("0"));
            //print("levelTime: " + FormatTime(levelTime));

            TimerCounter.GetComponent<Text>().text = "Time Left: " + FormatTime(levelTime);
        }
        else
        {
            levelTime = 0;
            //print("Times up!");
            TimerCounter.GetComponent<Text>().text = "Times up!";
        }
        AddTime();
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void AddTime()
    {
        if(PlayerCon.GetComponent<PlayerController_15>().AECollected <= 0)
        {
            for(int i = 0; i < AECollected; i++)
            {
                for (i = 0; i < ESpawn; i++)
                {
                    Vector3 posToSpawn = new Vector3(Random.Range(-25.0f, 25.0f), 0, Random.Range(-25.0f, 25.0f));

                    if (Random.Range(0, 2) < 1)
                    {
                        Instantiate(addEnergyPrefab, posToSpawn, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(minusEnergyPrefab, posToSpawn, Quaternion.identity);
                    }
                }
                PlayerCon.GetComponent<PlayerController_15>().AECollected++;
            }
        }
    }
}
