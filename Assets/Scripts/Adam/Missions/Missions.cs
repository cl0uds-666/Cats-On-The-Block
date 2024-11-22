using TMPro;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public int Mission = 0;
    public bool HasPurse = false;

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
                print("Mission 1: Press 1");
                break;
            case 2:
                print("Mission 2: Press 2");
                break;
            case 3:
                print("Mission 3: Press 3");
                break;
        }
    }
}
