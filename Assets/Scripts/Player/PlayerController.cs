
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;

    [Header("Rotation Settings")]
    public float lookSpeed = 0.5f;
    public float rollSpeed = 50f; // Speed for Q & E roll rotation

    [Header("Zoom Settings")]
    public float zoomSpeed = 5f;
    public float minZoom = 2f;
    public float maxZoom = 15f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private float rollInput;
    private float ascendDescendInput;
    //private float zoomInput;
    private bool isSprinting;
    private bool isLooking;

    private Transform camTransform;
    //private float currentZoom = 10f;

    [Header("Raycast Settings")]
    float rayLength = 100f;
    Color rayColor = Color.white;

    private void Awake()
    {
        camTransform = Camera.main.transform;
    }

    // Input System Functions
    public void OnMove(InputAction.CallbackContext context) => moveInput = context.ReadValue<Vector2>();
    public void OnLook(InputAction.CallbackContext context) => lookInput = context.ReadValue<Vector2>();
    public void OnLookEnable(InputAction.CallbackContext context) => isLooking = context.ReadValueAsButton();
    //public void OnZoom(InputAction.CallbackContext context) => zoomInput = context.ReadValue<float>();
    public void OnSprint(InputAction.CallbackContext context) => isSprinting = context.ReadValueAsButton();
    public void OnRoll(InputAction.CallbackContext context) => rollInput = context.ReadValue<float>();
    public void OnAscendDescend(InputAction.CallbackContext context) => ascendDescendInput = context.ReadValue<float>();
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && !MenuManager.Instance.isOpen)
        {
            Vector2 screenPosition;

            // Check for mouse or touch input
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
            {
                screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            }
            else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
            {
                screenPosition = Mouse.current.position.ReadValue();
            }
            else
            {
                return;
            }

            HandleTouch(screenPosition);
        }
    }

    private void Update()
    {
        // Camera Movement
        float speed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;
        Vector3 moveDirection = speed * Time.deltaTime * (camTransform.forward * moveInput.y + camTransform.right * moveInput.x);
        transform.position += new Vector3(moveDirection.x, 0, moveDirection.z); // Keep movement horizontal

        // Ascend & Descend (Space & Ctrl or Triggers)
        transform.position += Vector3.up * (ascendDescendInput * speed * Time.deltaTime);

        // Camera Rotation (Yaw & Pitch)
        if (isLooking)
        {
            float yaw = lookInput.x * lookSpeed;
            float pitch = -lookInput.y * lookSpeed; // Invert vertical look
            transform.Rotate(Vector3.up * yaw, Space.World);
            transform.Rotate(Vector3.right * pitch, Space.Self);
        }

        // Roll Rotation (Q/E or Gamepad Bumpers)
        float roll = rollInput * rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * roll, Space.Self);

        /*
        // Camera Zoom (Adjust Field of View)
        currentZoom -= zoomInput * zoomSpeed * Time.deltaTime;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        Camera.main.fieldOfView = currentZoom;
        */
       
    }

    void HandleTouch(Vector2 touchPosition) { 
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
