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
}
