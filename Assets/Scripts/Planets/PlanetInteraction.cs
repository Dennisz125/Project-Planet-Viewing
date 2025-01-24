using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    public CanvasGroup targetCanvas; // Assign the UI Canvas in the Inspector
    public Action action;

    void Start()
    {
        
    }

    public void OnRaycastHit()
    {
        Debug.Log($"{gameObject.name} was hit by a raycast!");

        MenuManager.Instance.OpenPlanetPage(gameObject.name);

    }
}
