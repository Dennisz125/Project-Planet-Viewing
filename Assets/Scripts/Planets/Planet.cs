using UnityEngine;
public class PlanetOrbit : MonoBehaviour
{
    public Transform sun; // Reference to the sun
    public float orbitSpeed = 10f; // Speed of orbit

    void Update()
    {
        if (sun != null)
        {
            // Rotate around the sun
            transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}