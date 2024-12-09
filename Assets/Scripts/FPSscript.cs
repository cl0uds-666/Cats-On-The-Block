using TMPro;
using UnityEngine;

public class FPSscript : MonoBehaviour
{
    public TextMeshProUGUI FPScount;
    public float fps;
    void Start()
    {
        FPScount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        fps = 1f / Time.deltaTime;
        FPScount.text = fps.ToString();
    }
}
