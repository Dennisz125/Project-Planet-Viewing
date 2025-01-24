using UnityEngine;

/// <summary>
/// Configeration Object for a planet/moon object
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "Planetary System/Planet Config")]
[System.Serializable]
public class PlanetConfig : ScriptableObject
{
    public GameObject prefab;
    public float size;
    public float speed;
    public float radius;
    public Material manualOverrideMaterial;

    public PlanetConfig[] moons;

    [TextArea(15, 15)]
    public string primaryInfo;
}
