using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Intro");
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

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
