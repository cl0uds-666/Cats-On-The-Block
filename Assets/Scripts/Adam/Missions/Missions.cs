using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    public int Mission = 0;
    public bool HasPurse = false;
    public GameObject Mission2Enemy;
    public List<GameObject> Mission3ParkEnemies;

    void Start()
    {
        SelectMission();
    }

    void Update()
    {
       
    }

    public void SelectMission()
    {
        Mission++;

        switch (Mission)
        {
            case 1:
                break;
            case 2:
                Mission2Enemy.SetActive(true);
                break;
            case 3:
                foreach(GameObject Enemy in Mission3ParkEnemies)
                {
                    Enemy.SetActive(true);
                }
                break;
            case 4:
                break;
        }
    }
}
