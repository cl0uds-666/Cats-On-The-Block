using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage CompassImage;
    void Update()
    {
        CompassImage.uvRect = new Rect(Camera.main.transform.localEulerAngles.y / 360, 0, 1, 1);
    }
}
