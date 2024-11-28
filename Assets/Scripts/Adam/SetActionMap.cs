using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;
public class SetActionMap : MonoBehaviour
{
    private Scene Current;
    void Start()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(Delay());
        Current = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var Map in GetComponent<PlayerInput>().actions.actionMaps)
        {
            Map.Disable();
        }

        if (Current.name == "Block out")
        {
            GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }

        else
        {
            GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        }
    }
}
