using System.Collections;
using UnityEngine;

/// <summary>
/// Controller for the Main Menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    public const string MAIN_MENU_SCENE = "Main Menu";

    public static MainMenu instance { get; private set; }

    public AudioClip menuMusic;
    public CanvasGroup mainPanel;
    private CanvasGroupController mainPanelController;

    private UIConfirmationMenu uiChoiceMenu => UIConfirmationMenu.instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainPanelController = new CanvasGroupController(this, mainPanel);
    }

    public void Click_StartNewGame()
    {
        //uiChoiceMenu.Show("Start a new game?", new UIConfirmationMenu.ConfirmationButton("Yes", StartNewGame), new UIConfirmationMenu.ConfirmationButton("No", null));
        
        StartNewGame();
    }

    /*
    public void LoadGame(VNGameSave file)
    {
        StartCoroutine(StartingGame());
    }
    */

    private void StartNewGame()
    {
        SystemManager.Instance.SpawnAndLoadNewSystem();
        StartCoroutine(StartingGame());
    }

    private IEnumerator StartingGame()
    {
        mainPanelController.Hide(speed: 0.3f);
        //AudioManager.instance.StopTrack(0);

        while (mainPanelController.isVisible)
            yield return null;

    }
}
