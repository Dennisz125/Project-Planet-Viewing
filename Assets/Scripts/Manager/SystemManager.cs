using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [SerializeField] private SystemConfig systemConfiguration;
    [SerializeField] private Transform centerOfSystem;

    [SerializeField] private Transform pages;
    [SerializeField] private GameObject planetPage;

    public static SystemManager Instance { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnAndLoadNewSystem()
    {
        SpawnAndLoadNewSystem(systemConfiguration);
        MenuManager.Instance.DynamicLoadNewPagesList();
    }

    private void SpawnAndLoadNewSystem(SystemConfig systemConfig)
    {
        foreach (var planet in systemConfig.planetConfigs)
        {
            // Load Planet's Model
            SpawnPlanetLikeGameObject(planet, centerOfSystem, out GameObject po);

            foreach (var moon in planet.moons)
            {
                SpawnPlanetLikeGameObject(moon, po.transform, out GameObject mo);
            }

            // Load Planet's UI page
            GameObject pui = Instantiate(planetPage, pages);
            pui.name = planet.name;

            PlanetInfoPage planetInfo = pui.GetComponent<PlanetInfoPage>();
            planetInfo.titleText.text = planet.name;
            planetInfo.primaryInfo.text = planet.primaryInfo;

        }
    }

    private void SpawnPlanetLikeGameObject(PlanetConfig planet, Transform parent, out GameObject po)
    {
        po = Instantiate(planet.prefab, parent);

        po.name = planet.name;
        po.transform.localPosition = new Vector3(0, 0, planet.semiMinorAxis);
        po.transform.localScale = Vector3.one * planet.size;

        PlanetOrbit poScript = po.GetComponent<PlanetOrbit>();
        poScript.SetValues(planet, parent);

        PlanetInteraction piScript = po.GetComponent<PlanetInteraction>();
        piScript.planetNameText.text = planet.name;

        SphereCollider collider = po.GetComponent<SphereCollider>();
        if (collider != null)
            collider.radius = planet.ColliderScale / 2;

        if (planet.manualOverrideMaterial != null) po.gameObject.GetComponentInChildren<Renderer>().material = planet.manualOverrideMaterial;
    }
}