
using UnityEngine;

/// <summary>
/// Controls the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of movement
    public float rotationSpeed = 100f; // Speed of rotation

    [Header("Debug Settings")]
    [SerializeField] int rayLength = 100;
    [SerializeField] Color rayColor = Color.white;

    void Update()
    {
        // Movement input
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Apply movement
        transform.Translate(moveRight, 0, moveForward);

        if (Input.GetKey(KeyCode.Space))
        {
            // Rotation input (mouse movement)
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Apply rotation
            transform.Rotate(-rotationY, rotationX, 0);

            //TODO: Add Q & E input
        }

        /*
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended) // Detect tap
            {
                HandleTouch(touch.position);
            }
        }
        */

        // Handle mouse input (for testing in the editor)
        if (Input.GetMouseButtonDown(0) && !MenuManager.Instance.isOpen)
        {
            HandleTouch(Input.mousePosition);
        }
    }

    void HandleTouch(Vector3 touchPosition)
    {
        // Raycast from the touch position into the scene
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, rayColor, 1.0f); // Draw the debug ray
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has the PlanetInteraction script
            PlanetInteraction planet = hit.transform.GetComponent<PlanetInteraction>();
            if (planet != null)
            {
                // Call the planet's interaction function
                planet.OnRaycastHit();
            }
        }
    }
}
