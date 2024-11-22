using Unity.Cinemachine;
using UnityEngine;

public class TextBoxLookAt : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }
}
