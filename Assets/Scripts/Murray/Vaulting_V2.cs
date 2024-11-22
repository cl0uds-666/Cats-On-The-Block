using UnityEngine;

public class Vaulting_V2 : MonoBehaviour
{
    public GameObject Player;
    

    private bool touching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touching == true)
        {
            Vector3 Current_Position = Player.transform.position;
            Vector3 New_Position = new Vector3(Current_Position.x, Current_Position.y, Current_Position.z + 2);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.transform.position = New_Position;
            }
            else if (Input.GetKeyUp(KeyCode.Joystick1Button0))
            {
                Player.transform.position = New_Position;
            }
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Trigger")
    //    {
    //        touching = true;
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.tag == "Trigger")
    //    {
    //        touching = false;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cover")
        {
            touching = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cover")
        {
            touching = false;
        }
    }
}
