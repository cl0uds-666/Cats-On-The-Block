using UnityEngine;

public class Respawn : MonoBehaviour
{
    GameObject Player;
    GameObject Respawn_point;
    private BoxCollider Box_Collider;
    private CapsuleCollider Player_Collider;
    private bool touching;
    private bool Is_Moving;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Player != null)
        {
            Player_Collider = GetComponent<CapsuleCollider>();
        }
        else if (Respawn_point != null)
        {
            Box_Collider = GetComponent<BoxCollider>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (touching && Player != null)
        {
            SaveData();

        }

    }
    void SaveData()
    {
        float Player_Position_X = Player.transform.position.x;
        float Player_Position_Y = Player.transform.position.y;
        float Player_Position_Z = Player.transform.position.z;

        PlayerPrefs.SetFloat("Object_Position_X", Player_Position_X);
        PlayerPrefs.SetFloat("Object_Position_Y", Player_Position_Y);
        PlayerPrefs.SetFloat("Object_Position_Z", Player_Position_Z);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn_Point")
        {
            Player =collision.gameObject;
            Player_Collider = GetComponent<CapsuleCollider>();
            touching = true;
        }


    }
    private void OnCollisionExit(Collision collision)
    {
        touching = false;
        Player = null;

    }


}
