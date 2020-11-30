using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;

    public GameObject addEnergyPrefab;
    public GameObject minusEnergyPrefab;

    public int numberOfSpawn;
    public float levelTime;
    // Start is called before the first frame update
    void Start()
    {
        if (gmInstance == null)
        {
            gmInstance = this;
        }
        //Vector3 posToSpawn = new Vector3(Random.RandomRange(-10.0f, 10.0f), 0, Random.RandomRange(-10.0f, 10.0f));
        //Instantiate(addEnergyPrefab, posToSpawn, Quaternion.identity);
        if(levelTime > 0)
        {
            for (int i = 0; i < numberOfSpawn; i++)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));

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
        if(levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            //print("levelTime: " + levelTime.ToString("0"));
            print("levelTime: " + FormatTime(levelTime));
        }
        else
        {
            levelTime = 0;
            print("Times up!");
        }
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
