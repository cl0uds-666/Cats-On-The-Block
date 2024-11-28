using UnityEngine;
using System.Collections.Generic;

public class Missions : MonoBehaviour
{
    public int Mission = 0;
    public bool HasPurse = false;
    public GameObject Mission1Enemy;
    public GameObject Mission2Enemy;
    public List<GameObject> Mission3ParkEnemies;
    public List<GameObject> Mission4ConstructionEnemies;
    public GameObject MissionIcon;
    public GameObject MissionNPC;
    public GameObject ParkIconSpawn;
    public GameObject ConstructionIconSpawn;
    public GameObject PurseObject;
    public GameObject Pistol;
    public GameObject Rifle;
    public GameObject Grenade;

    void Start()
    {
        SelectMission();
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
                }
            }
            
            else
            {
                if (!HasPurse)
                {
                    if (PurseObject != null)
                    {
                        MissionIcon.transform.position = new Vector3(PurseObject.transform.position.x, MissionIcon.transform.position.y, PurseObject.transform.position.z);
                    }
                }

                else
                {
                    MissionIcon.transform.position = new Vector3(MissionNPC.transform.position.x, MissionIcon.transform.position.y, MissionNPC.transform.position.z);
                }
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
                if (Pistol != null)
                {
                    MissionIcon.transform.position = new Vector3(Pistol.transform.position.x, MissionIcon.transform.position.y, Pistol.transform.position.z);
                }
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
                if (Rifle != null)
                {
                    MissionIcon.transform.position = new Vector3(Rifle.transform.position.x, MissionIcon.transform.position.y, Rifle.transform.position.z);
                }
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
                if (Grenade != null)
                {
                    MissionIcon.transform.position = new Vector3(Grenade.transform.position.x, MissionIcon.transform.position.y, Grenade.transform.position.z);
                }
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
                foreach (GameObject Enemy in Mission4ConstructionEnemies)
                {
                    Enemy.SetActive(true);
                }
                break;
        }
    }
}
