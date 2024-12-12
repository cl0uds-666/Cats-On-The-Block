using UnityEngine;
using UnityEngine.UI;

public class settingsliders : MonoBehaviour
{
    private Slider slider;
    public GameObject Source;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        slider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            Source.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
            
            if (slider.CompareTag("Music"))
            {
                slider.value = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
        
        else
        {
            Music();
        }

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume");

            if (slider.CompareTag("Master"))
            {
                slider.value = PlayerPrefs.GetFloat("MasterVolume");
            }
        }

        else
        {
            Master();
        }
    }

    public void Music()
    {
        Source.GetComponent<AudioSource>().volume = slider.value;
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
        PlayerPrefs.Save();
    }

    public void Master()
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        PlayerPrefs.Save();
    }
}
