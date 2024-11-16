using UnityEngine;

public class Missions : MonoBehaviour
{
    int Mission = 0;

    void Start()
    {
        SelectMission();
    }

    void Update()
    {
        if (Mission == 1)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                SelectMission();
            }
        }

        else if (Mission == 2)
        {
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                SelectMission();
            }
        }

        else if (Mission == 3)
        {
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                SelectMission();
            }
        }
    }

    private void SelectMission()
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
