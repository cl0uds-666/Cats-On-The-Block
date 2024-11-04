using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Image waterFillImage;                // Reference to the water fill image

    public void UpdateWaterBar(float ammoPercentage)
    {
        waterFillImage.fillAmount = ammoPercentage;
    }
}
