using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public CanvasGroup group;
    public bool FadeIn = false;
    public bool FadeOut = false;
    public float ScreenTime;
    public GameObject UON, Pegi, Panel;
    private int Count = 0;
    
    void Update()
    {
        if (XInputController.current != null && XInputController.current.bButton.isPressed)
        {
            SceneManager.LoadScene("Main Menu");
        }

        if (FadeIn)
        {
            if (group.alpha < 1)
            {
                group.alpha += Time.deltaTime;
                if (group.alpha >= 1)
                {
                    StartCoroutine(Fade());
                }
            }
        }

        if (FadeOut)
        {
            if (group.alpha >= 0)
            {
                group.alpha -= Time.deltaTime;
                if (group.alpha == 0)
                {
                    FadeOut = false;
                    Count++;

                    if (Count == 1)
                    {
                        UON.SetActive(false);
                        Pegi.SetActive(true);
                        FadeIn = true;
                    }

                    else
                    {
                        Panel.SetActive(false);

                        StartCoroutine(VideoFinish());
                    }
                }
            }
        }
    }

    private IEnumerator VideoFinish()
    {
        GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds((float)GetComponent<VideoPlayer>().length);
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator Fade()
    {
        FadeIn = false;
        yield return new WaitForSeconds(ScreenTime);
        FadeOut = true;
    }
}
