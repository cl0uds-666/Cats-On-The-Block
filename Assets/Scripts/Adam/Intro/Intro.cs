using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(VideoFinish());
    }
    void Update()
    {
        if (XInputController.current.bButton.isPressed)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private IEnumerator VideoFinish()
    {
        yield return new WaitForSeconds((float)GetComponent<VideoPlayer>().length);
        SceneManager.LoadScene("Main Menu");
    }
}
