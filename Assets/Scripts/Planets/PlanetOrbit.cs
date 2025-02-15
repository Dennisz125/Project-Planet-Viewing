using UnityEngine;
public class PlanetOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform center; // Reference to the center of the orbit    public float semiMajorAxis = 10f; // Longest radius of the ellipse
    public float semiMajorAxis = 10f; // Longest radius of the ellipse
    public float semiMinorAxis = 7f;  // Shortest radius of the ellipse
    public float orbitSpeed = 10f; // Speed of the orbit
    public float inclination = 0f; // Tilt angle in degrees

    private float orbitProgress = 0f; // Tracks progress along the orbit

    [Header("Other Settings")]
    public bool isMoon = false;

    public void SetValues(PlanetConfig config, Transform centerOfOrbit = null) 
    { 
        semiMajorAxis = config.semiMajorAxis;
        semiMinorAxis = config.semiMinorAxis;
        orbitSpeed = config.speed;
        inclination = config.inclination;

        if (centerOfOrbit != null)
            center = centerOfOrbit;
    }

    void Update()
    {
        if (center != null)
        {
            // Update orbit progress
            orbitProgress += (orbitSpeed * OrbitSpeedController.globalOrbitSpeed * Time.deltaTime) % 360;

            // Convert degrees to radians
            float angleRad = orbitProgress * Mathf.Deg2Rad;

            // Compute elliptical position
            float x = semiMajorAxis * Mathf.Cos(angleRad);
            float z = semiMinorAxis * Mathf.Sin(angleRad);

            // Apply inclination (tilt)
            Quaternion rotation = Quaternion.Euler(inclination, 0, 0);
            Vector3 orbitPosition = rotation * new Vector3(x, 0, z);

            // Set position relative to central body
            transform.position = center.position + orbitPosition;
        }
    }
}