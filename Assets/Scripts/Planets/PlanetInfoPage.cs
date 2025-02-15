using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoPage : MonoBehaviour
{
    public TextMeshProUGUI titleText;

    public TextMeshProUGUI primaryInfo;
    public TextMeshProUGUI secondaryInfo;

    public RawImage planetImage;

    public Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(OpenAllGameplayUIPages);
    }

    private void OpenAllGameplayUIPages()
    {
        MenuManager.Instance.OpenAllGameplayPages();
    }
}
