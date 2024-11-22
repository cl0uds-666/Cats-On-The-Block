using TMPro;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public int Mission = 0;
    public bool HasPurse = false;
    public GameObject Mission2Enemy;

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
                print("Mission 3: Press 3");
                break;
        }
    }
}
