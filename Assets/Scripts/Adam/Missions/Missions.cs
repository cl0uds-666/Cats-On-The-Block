using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public int Mission = 0;
    public bool HasPurse = false;
    public GameObject Mission1Enemy;
    public GameObject Mission2Enemy, LineRenderer;
    public List<GameObject> Mission3ParkEnemies;
    public List<GameObject> Mission4ConstructionEnemies;
    public GameObject MissionIcon, A;
    public GameObject MissionNPC;
    public GameObject ParkIconSpawn;
    public GameObject ConstructionIconSpawn;
    public GameObject PurseObject;
    public GameObject Pistol;
    public GameObject Rifle;
    public GameObject Grenade, UnlockScreen, StickPrompts, LeftPrompts, RightPrompts;
    public TextMeshProUGUI ObjectiveText, RightPromptText, LeftPromptText;
    public Vector3 CheckpointPosition;
    public GameObject Player;
    public float PromptTime, DistanceFromEnemy;
    public Image LT, RT, LB, RB, Pause;
    public Transform[] Mission1Points, Mission2Points, Mission3Points, Mission4Points;

    void Start()
    {
        SelectMission();
        CheckpointPosition = Player.transform.position;
    }

    void Update()
    {
        if (Mission == 1)
        {
            if (!HasPurse)
            {
                if (Mission1Enemy != null)
                {
                    MissionIcon.transform.position = new Vector3(Mission1Enemy.transform.position.x, MissionIcon.transform.position.y, Mission1Enemy.transform.position.z);
                    LineRenderer.GetComponent<MissionLinepath>().SetLine(Mission1Points);

                    if (Vector3.Distance(transform.position, Mission1Enemy.transform.position) < DistanceFromEnemy)
                    {
                        RightPrompts.GetComponent<Image>().sprite = RT.sprite;
                        A.SetActive(false);
                        RightPromptText.gameObject.SetActive(true);
                        RightPrompts.SetActive(true);
                    }
                }
            }
            
            else
            {
                LeftPrompts.SetActive(false);
                RightPrompts.SetActive(false);
                if (PurseObject != null)
                {
                    MissionIcon.transform.position = new Vector3(PurseObject.transform.position.x, MissionIcon.transform.position.y, PurseObject.transform.position.z);
                }

                MissionIcon.transform.position = new Vector3(MissionNPC.transform.position.x, MissionIcon.transform.position.y, MissionNPC.transform.position.z);
            }
        }

        else if (Mission == 2)
        {
            if (Mission2Enemy != null)
            {
                MissionIcon.transform.position = new Vector3(Mission2Enemy.transform.position.x, MissionIcon.transform.position.y, Mission2Enemy.transform.position.z);
            }

            else
            {
                A.SetActive(false);
                UnlockScreen.SetActive(true);
                LeftPromptText.text = "Swap Weapon";
                RightPromptText.text = "Shoot";
                RightPrompts.GetComponent<Image>().sprite = RT.sprite;
                LeftPrompts.GetComponent<Image>().sprite = RB.sprite;
                RightPrompts.SetActive(true);
                LeftPrompts.SetActive(true);
                SelectMission();
            }
        }

        else if (Mission == 3)
        {
            if (Mission3ParkEnemies.Count > 0)
            {
                MissionIcon.transform.position = new Vector3(ParkIconSpawn.transform.position.x, MissionIcon.transform.position.y, ParkIconSpawn.transform.position.z);
            }

            else
            {
                UnlockScreen.SetActive(true);
                SelectMission();
            }
        }

        else if (Mission == 4)
        {
            if (Mission4ConstructionEnemies.Count > 0)
            {
                MissionIcon.transform.position = new Vector3(ConstructionIconSpawn.transform.position.x, MissionIcon.transform.position.y, ConstructionIconSpawn.transform.position.z);
            }

            else
            {
                UnlockScreen.SetActive(true);
                SelectMission();
            }
        }

        else
        {
            MissionIcon.SetActive(false);
        }
    }

    public void SelectMission()
    {
        Mission++;

        CheckpointPosition = Player.transform.position;

        switch (Mission)
        {
            case 1:
                ObjectiveText.text = "Knock out the thief and give the purse back";
                StickPrompts.SetActive(true);
                break;
            case 2:
                LineRenderer.GetComponent<MissionLinepath>().SetLine(Mission2Points);
                ObjectiveText.text = "Find and Knock out the armed cat";
                Mission2Enemy.SetActive(true);
                break;
            case 3:
                LineRenderer.GetComponent<MissionLinepath>().SetLine(Mission3Points);
                GetComponent<WeaponSwitching>().weapons.Add(Pistol);
                ObjectiveText.text = "Eliminate all enemy cats in the park";
                foreach (GameObject Enemy in Mission3ParkEnemies)
                {
                    Enemy.SetActive(true);
                }
                break;
            case 4:
                LineRenderer.GetComponent<MissionLinepath>().SetLine(Mission4Points);
                GetComponent<WeaponSwitching>().weapons.Add(Rifle);
                ObjectiveText.text = "Eliminate all enemy cats in the construction site";
                foreach (GameObject Enemy in Mission4ConstructionEnemies)
                {
                    Enemy.SetActive(true);
                }
                break;
            case 5:
                GetComponent<WeaponSwitching>().weapons.Add(Grenade);
                break;
        }
    }

    public void Respawn()
    {
        // reset vinny to the checkpoint made when the current mission started.
        Player.transform.position = CheckpointPosition;

        var playerStats = Player.GetComponent<Player_Stats>();
        if (playerStats != null)
        {
            playerStats.ResetHealth();
        }

        if(Mission == 1 && Mission1Enemy != null)
        {
            Mission1Enemy.SetActive(true);
            HasPurse = false;
        }
        else if (Mission == 2 && Mission2Enemy != null)
        {
            Mission2Enemy.SetActive(true);
        }
        else if (Mission == 3 )
        {
            foreach(GameObject Enemy in Mission3ParkEnemies)
            {
            if (Enemy != null)Enemy.SetActive(true);
            }
        }
        else if(Mission == 4 ) 
        {
            foreach (GameObject Enemy in Mission4ConstructionEnemies)
            {
                if (Enemy != null) Enemy.SetActive(true);
            }
        }

    }
}
