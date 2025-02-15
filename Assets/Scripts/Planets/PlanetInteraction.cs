using System;
using TMPro;
using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    public TextMeshProUGUI planetNameText;
    public Action action;

    void Start()
    {
        
    }

    public void OnRaycastHit()
    {
        Debug.Log($"{gameObject.name} was hit by a raycast!");

        MenuManager.Instance.OpenPlanetPage(gameObject.name);
        MenuManager.Instance.CloseAllGameplayPages();
    }
}
