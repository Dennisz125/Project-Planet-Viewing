using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { private set; get; }

    private MenuPage activePage = null;
    public bool isOpen { private set; get; } = false;

    public GameObject PlanetRootPage;

    [SerializeField] private CanvasGroup root;
    [SerializeField] private MenuPage[] pages;
    [SerializeField] private MenuPage[] persistencePage;

    private CanvasGroupController rootCG;

    private UIConfirmationMenu uiChoiceMenu => UIConfirmationMenu.instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rootCG = new CanvasGroupController(this, root);
    }

    public void DynamicLoadNewPagesList()
    {
        pages = PlanetRootPage.GetComponentsInChildren<MenuPage>();

        List<MenuPage> list = new List<MenuPage>();
        list.AddRange(pages.ToList());
        list.AddRange(persistencePage.ToList());

        pages = list.ToArray();
    }

    private MenuPage GetPage(MenuPage.PageType pageType, string name = null)
    {
        return pages.FirstOrDefault(page => page.pageType == pageType && (string.IsNullOrEmpty(name) || page.name == name));
    }

    public void OpenSavePage()
    {
        var page = GetPage(MenuPage.PageType.SaveAndLoad);
        //var slm = page.animator.GetComponentInParent<SaveAndLoadMenu>();
        //slm.menuFunction = SaveAndLoadMenu.MenuFunction.save;
        OpenPage(page);
    }

    public void OpenLoadPage()
    {
        var page = GetPage(MenuPage.PageType.SaveAndLoad);
        //var slm = page.animator.GetComponentInParent<SaveAndLoadMenu>();
        //slm.menuFunction = SaveAndLoadMenu.MenuFunction.load;
        OpenPage(page);
    }

    public void OpenConfigPage()
    {
        var page = GetPage(MenuPage.PageType.Config);
        OpenPage(page);
    }

    public void OpenHelpPage()
    {
        var page = GetPage(MenuPage.PageType.Help);
        OpenPage(page);
    }

    public void OpenPlanetPage(string planetName = "")
    {
        if (planetName.ToLower() == "default") planetName = "";
        var page = GetPage(MenuPage.PageType.Planet, planetName);
        OpenPage(page);
    }

    public void OpenNAPage()
    {
        var page = GetPage(MenuPage.PageType.NA);
        OpenPage(page);
    }

    private void OpenPage(MenuPage page)
    {
        if (page == null)
            return;

        if (activePage != null && activePage != page)
            activePage.Close();

        page.Open();
        activePage = page;

        if (!isOpen)
            OpenRoot();
    }

    public void OpenAllGameplayPages()
    {
        foreach (var page in pages)
        {
            if (page.pageType == MenuPage.PageType.Gameplay)
                page.Open();
        }
    }

    public void CloseAllGameplayPages()
    {
        foreach (var page in pages)
        {
            if (page.pageType == MenuPage.PageType.Gameplay)
                page.Close();
        }
    }

    public void OpenRoot()
    {
        rootCG.Show();
        rootCG.SetInteractableState(true);
        isOpen = true;
    }

    public void CloseRoot()
    {
        rootCG.Hide();
        rootCG.SetInteractableState(false);
        activePage = null;
        isOpen = false;
    }

    public void Click_Home()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu.MAIN_MENU_SCENE);

    }

    public void Click_Quit()
    {
        //uiChoiceMenu.Show("Quit to desktop?", new UIConfirmationMenu.ConfirmationButton("Yes", () => Application.Quit()), new UIConfirmationMenu.ConfirmationButton("No", null));
        Application.Quit();
    }
}
