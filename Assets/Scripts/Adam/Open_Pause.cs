using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem;

public class Open_Pause : MonoBehaviour
{
    public GameObject Panel;
    bool CanToggle = true;
    //private void Update()
    //{
    //    if (CanToggle)
    //    {
    //        togglePause();
    //    }
        
    //}

    //private void togglePause()
    //{
    //    if (Input.GetKeyDown(KeyCode.P) || XInputController.current.startButton.isPressed && CanToggle)
    //    {
    //        CanToggle = false;
    //        if (Panel.activeSelf)
    //        {

    //            Panel.SetActive(false);
    //            Time.timeScale = 1.0f;
    //        }

    //        else if (!Panel.activeSelf)
    //        {
    //            Panel.SetActive(true);
    //            Time.timeScale = 0f;
    //        }
    //        //CanToggle = true;
    //    }

    //    if (XInputController.current.startButton. && !CanToggle)
    //    {

    //    }

    //}

    void OnPrevious()
    {
        print("Previous");
    }


    //void OnPause(InputValue value)
    //{
    //    print("Pause");
    //    if (CanToggle)
    //    {
    //        CanToggle = false;
    //        if (Panel.activeSelf)
    //        {

    //            Panel.SetActive(false);
    //            Time.timeScale = 1.0f;
    //        }

    //        else
    //        {
    //            Panel.SetActive(true);
    //            Time.timeScale = 0f;
    //        }
    //    }
        

    //}

  
}
