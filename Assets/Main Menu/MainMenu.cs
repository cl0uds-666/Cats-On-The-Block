using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void OnPlayButton () 
   {
	SceneManager.LoadScene("Block out");
   }

   public void OnOptionButton () 
   {
	SceneManager.LoadScene("Options Menu");
   }

        
   public void OnQuitButton ()
   {
    Application.Quit();
   }

    public void OnAccessibilityButton()
    {
        SceneManager.LoadScene("Accessability Menu");
    }

    public void OnSoundButton()
    {
        SceneManager.LoadScene("Sound Menu");
    }

    public void OnControlButton()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
