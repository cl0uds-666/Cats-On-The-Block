using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void OnPlayButton () 
   {
	SceneManager.LoadScene(1);
   }

   public void OnOptionButton () 
   {
	SceneManager.LoadScene(2);
   }

        
   public void OnQuitButton ()
   {
    Application.Quit();
   }

    public void OnAccessibilityButton()
    {
        SceneManager.LoadScene(3);
    }

    public void OnSoundButton()
    {
        SceneManager.LoadScene(4);
    }

    public void OnControlButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
