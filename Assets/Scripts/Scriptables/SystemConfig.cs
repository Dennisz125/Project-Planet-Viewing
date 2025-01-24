using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Configeration Object for a Planetary System
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "Planetary System/System Config")]
[System.Serializable]
public class SystemConfig : ScriptableObject
{
    public PlanetConfig[] planetConfigs;
}
