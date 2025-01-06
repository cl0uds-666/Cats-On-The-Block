using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class BulletVibration : MonoBehaviour
{
    public float VibrationTime;
    public bool CanVibrate;

    void Update()
    {
        if (XInputController.current != null)
        {
            if (CanVibrate)
            {
                StartCoroutine(Vibration());
            }
            
            else
            {
                XInputController.current.SetMotorSpeeds(0f, 0f);
            }
        }
    }

   private IEnumerator Vibration()
    {
        XInputController.current.SetMotorSpeeds(25f, 50f);
        yield return new WaitForSeconds(VibrationTime);
        CanVibrate = false;
    }
}
