using UnityEngine;

public class Clamp_Minimap_Icons : MonoBehaviour
{
    public Camera MiniMapCamera;
    private GameObject Player;
    
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //float X = Mathf.Clamp(transform.position.x, Player.transform.position.x - (Player.transform.position.x - transform.position.x), Player.transform.position.x + (Player.transform.position.x - transform.position.x));
        //float Z = Mathf.Clamp(transform.position.z, Player.transform.position.z - (Player.transform.position.z - transform.position.z), Player.transform.position.z + (Player.transform.position.z - transform.position.z));
        //transform.position = new Vector3(X, transform.position.y, Z);

        
    }
}
