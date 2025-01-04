using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn_Button_script : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
        
    }
     

    // Update is called once per frame
    void Update()
    {
         
    }

    public void OnRespawnButton ()
    {
        SceneManager.LoadScene("Block out");
        var missions = FindAnyObjectByType<Missions>();
        missions.Respawn();
        print("Reapwnn");
    }
}
