using UnityEngine;
using UnityEngine.UIElements;

public class Vaulting_V2 : MonoBehaviour
{
    public GameObject Player;
    private Collider playerCollider;
    private bool touching;
    private bool isMoving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (Player != null)
        {
            playerCollider = Player.GetComponent<Collider>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (touching && Player != null && !isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Vector3 Current_Position = Player.transform.position;
                Vector3 New_Position = new Vector3(Current_Position.x, Current_Position.y, Current_Position.z + 2);

                StartCoroutine(MovePlayerAndEnableCollider(New_Position));
            }
        }
    }
    // Temporarily disables the player's collider, moves them to the target position, waits briefly, and then re-enables the collider.
    System.Collections.IEnumerator MovePlayerAndEnableCollider(Vector3 targetPosition)
    {
        isMoving = true;

        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        Player.transform.position = targetPosition;

        yield return new WaitForSeconds(0.1f);

        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        isMoving = false;
    }
    // Detects when the Player collides with a "Cover" object, enabling interaction and storing references, 
    // and clears those references when the collision ends.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cover")
        {
            Player = collision.gameObject;
            playerCollider = Player.GetComponent<Collider>();
            touching = true;
             
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cover")
        {
            
            touching = false;
            Player = null;
            playerCollider.enabled = false;
        }
    }
}
