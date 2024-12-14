using UnityEngine;

public class GetSettings : MonoBehaviour
{
    public GameObject Source;
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume");
        }

        else
        {
            AudioListener.volume = 0.5f;
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            Source.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
        }

        else
        {
            Source.GetComponent<AudioSource>().volume = 0.5f;
        }
    }
}
