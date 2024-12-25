
using UnityEngine;

/// <summary>
/// Controls the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of movement
    public float rotationSpeed = 100f; // Speed of rotation

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

        
    }
}
