using TMPro;
using UnityEngine;
using UnityEngine.AI;
public class NPC_Interaction : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent Agent;
    public float Speed;
    public Canvas canvas;
    public TextMeshProUGUI Dialogue;
    public string[] DialogueOptions;
    private int Random;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        canvas.gameObject.SetActive(false);
        Random = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 5f)
        {
            Agent.speed = 0f;
            canvas.gameObject.SetActive(true);
            transform.LookAt(Player.transform.position);
            canvas.transform.LookAt(new Vector3(Camera.main.transform.position.x, canvas.transform.position.y, Camera.main.transform.position.z));
            RandomDialogue();
        }

        else
        {
            Agent.speed = Speed;
            canvas.gameObject.SetActive(false);
            Random = -1;
        }
    }

    void RandomDialogue()
    {
        if (Random == -1)
        {
            Random = UnityEngine.Random.Range(0, DialogueOptions.Length);
            Dialogue.text = DialogueOptions[Random];
        }
    }
}
