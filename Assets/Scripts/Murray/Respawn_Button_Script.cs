using UnityEngine;

public class Respawn_Button_script : MonoBehaviour
{
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Load_Data();
        
    }
    void Load_Data()
    {
        float Position_X = PlayerPrefs.GetFloat("Object_Position_X", 0f);
        float Position_Y = PlayerPrefs.GetFloat("Object_Position_Y", 0f);
        float Position_Z = PlayerPrefs.GetFloat("Object_Position_Z", 0f);

        Vector3 Respawn_Position = new Vector3(Position_X, Position_Y, Position_Z);


        Player.transform.position = Respawn_Position;


        //transform.position.x = PlayerPrefs.GetFloat(Position_X)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
