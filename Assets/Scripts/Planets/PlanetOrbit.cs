using UnityEngine;
public class PlanetOrbit : MonoBehaviour
{
    public Transform center; // Reference to the center of the orbit
    public float orbitSpeed = 10f; // Speed of orbit
    public bool isMoon = false;

    void Update()
    {
        if (center != null)
        {
            // Rotate around the center
            transform.RotateAround(center.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"You clicked {this.name}");
    }
}