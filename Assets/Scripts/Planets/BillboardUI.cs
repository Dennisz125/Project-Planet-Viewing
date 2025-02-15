using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Transform player;
    [SerializeField] GameObject panel;

    void Start()
    {
        // Find the player using the Main Camera (Assumes player is camera)
        player = Camera.main.transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Make the UI face the camera
            transform.LookAt(player);

            // Keep the UI upright by canceling any unwanted rotation
            transform.rotation = player.rotation;

            /*
            // Scale the UI based on distance
            float distance = Vector3.Distance(transform.position, player.position);
            transform.localScale = Vector3.one * Mathf.Clamp(distance * 0.0005f, 0.0005f, 0.002f);
            */
        }
    }
}

