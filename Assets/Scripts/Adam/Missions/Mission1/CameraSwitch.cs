using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CameraSwitch : MonoBehaviour
{
    public bool SwitchCamera = false;
    public CinemachineCamera PlayerCamera;
    public GameObject Enemy;
    public GameObject AttackBox;
    public GameObject Player;
    private float NormalSpeed;
    private float NormalSprintSpeed;
    public GameObject NPCTextBox;
    public GameObject NPC;
    public GameObject SkipButton, LeftPrompts, RightPrompts;
    private void Start()
    {
        Enemy.GetComponent<EnemyMovement>().enabled = false;
        Enemy.GetComponent<Melee_Enemy>().enabled = false;
        AttackBox.SetActive(false);
        NormalSpeed = Player.GetComponent<Movement>().Speed;
        NormalSprintSpeed = Player.GetComponent<Movement>().SprintSpeed;
    }

    void Update()
    {
        if (SwitchCamera)
        {
            SkipButton.SetActive(true);
            NPC.transform.LookAt(new Vector3(Player.transform.position.x, NPC.transform.position.y, Player.transform.position.z));

            if (XInputController.current != null)
            {
                if (XInputController.current.bButton.isPressed)
                {
                    Skip();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Skip();
            }
        }
    }

    private void Skip()
    {
        SwitchCamera = false;
        SkipButton.SetActive(false);
        PlayerCamera.Prioritize();
        NPCTextBox.SetActive(false);
        Player.GetComponent<Movement>().Speed = NormalSpeed;
        Player.GetComponent<Movement>().SprintSpeed = NormalSprintSpeed;
        Player.GetComponent<Movement>().CanDash = true;

        if (Enemy != null)
        {
            Enemy.GetComponent<EnemyMovement>().enabled = true;
        }
        LeftPrompts.SetActive(true);
    }
}
