using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class Open_Pause : MonoBehaviour
{
    public GameObject Panel, UnlockScreen, MiniMap;
    private bool IsPressed;

    private void Update()
    {
        if (XInputController.current != null)
        {
            if (XInputController.current.startButton.isPressed)
            {
                if (!IsPressed)
                {
                    IsPressed = true;

                    if (!UnlockScreen.activeSelf)
                    {
                        if (Panel.activeSelf)
                        {
                            GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                            Panel.SetActive(false);
                            MiniMap.SetActive(true);
                            Time.timeScale = 1.0f;
                        }

                        else
                        {
                            GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                            Panel.SetActive(true);
                            MiniMap.SetActive(false);
                            Time.timeScale = 0f;
                        }
                    }
                }
            }

            else
            {
                IsPressed = false;
            }
        }
    }
}
