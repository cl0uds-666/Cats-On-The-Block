using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XInput;

public class NPC_Collider : MonoBehaviour
{
    private GameObject Player;
    public TextMeshProUGUI NPC1Text;
    public GameObject NPCTextBox;
    public GameObject Camera;
    
    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.GetComponent<Missions>().HasPurse && Camera != null)
            {
                Player.GetComponent<Movement>().Speed = 0f;
                Player.GetComponent<Movement>().SprintSpeed = 0f;

                if (Vector3.Distance(transform.position, GetComponent<NPC_Roam_AI>().WayPoints[GetComponent<NPC_Roam_AI>().WayPoints.Length - 1].gameObject.transform.position) < 1f)
                {
                    Player.GetComponent<Missions>().SelectMission();
                    GetComponent<BoxCollider>().enabled = false;
                }

                Camera.GetComponent<CinemachineCamera>().Prioritize();
                Camera.GetComponent<CameraSwitch>().SwitchCamera = true;

                if (Player.GetComponent<Missions>().Mission == 1)
                {
                    NPC1Text.text = "Thanks for getting my purrrse back! Follow me to the fashion shop";
                    Player.GetComponent<Missions>().ObjectiveText.text = "Follow the cat to the fashion shop";
                }

                else
                {
                    NPC1Text.text = "I got word of someone armed with a gun scaring people in the area, go find and stop them";
                }
                
                NPCTextBox.SetActive(true);
                GetComponent<BoxCollider>().enabled = false;
                Player.GetComponent<Movement>().CanDash = false;
            }
        } 
    }

    private void Update()
    {
        if (XInputController.current != null && XInputController.current.bButton.isPressed)
        {
            Skip();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Skip();
        }
        
        if (Vector3.Distance(transform.position, GetComponent<NPC_Roam_AI>().WayPoints[GetComponent<NPC_Roam_AI>().WayPoints.Length - 1].gameObject.transform.position) < 1f && Player.GetComponent<Missions>().Mission == 1)
        {
            Camera = GameObject.Find("Mission 2 NPC Camera");
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void Skip()
    {
        if (Player.GetComponent<Missions>().HasPurse && Camera.GetComponent<CameraSwitch>().SwitchCamera)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NPC_Roam_AI>().enabled = true;
            Player.GetComponent<Movement>().CanDash = true;
        }
    }
}
