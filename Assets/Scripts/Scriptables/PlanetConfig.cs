using UnityEngine;

/// <summary>
/// Configeration Object for a planet/moon object
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "Planetary System/Planet Config")]
[System.Serializable]
public class PlanetConfig : ScriptableObject
{
    public GameObject prefab;
    [Header("Planet's Properity")]
    public float size;
    public float speed;

    [Header("Elliptical Orbit Settings")]
    public float semiMajorAxis; // Longest radius of the ellipse
    public float semiMinorAxis;  // Shortest radius of the ellipse
    public float inclination; // Tilt angle in degrees

    [Header("Other Settings")]
    public Material manualOverrideMaterial;
    [Tooltip("Set the manual scale for the planet. Set higher for the smaller planets. 1 is 100%")]
    public float ColliderScale = 1;

    public PlanetConfig[] moons;

    [TextArea(15, 15)]
    public string primaryInfo;
}
