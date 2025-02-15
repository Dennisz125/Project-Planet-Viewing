using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OrbitSpeedController : MonoBehaviour
{
    public Slider speedSlider; // Reference to the UI Slider
    public static float globalOrbitSpeed = 1f; // Default speed multiplier

    void Start()
    {
        // Initialize slider value
        if (speedSlider != null)
        {
            speedSlider.value = globalOrbitSpeed;
            speedSlider.onValueChanged.AddListener(UpdateOrbitSpeed);
        }
    }

    public void UpdateOrbitSpeed(float newSpeed)
    {
        globalOrbitSpeed = newSpeed;
    }
}
