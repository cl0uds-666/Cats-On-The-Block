using TMPro;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "x" + Player.GetComponent<Player_Stats>().Health.ToString();
    }
}
