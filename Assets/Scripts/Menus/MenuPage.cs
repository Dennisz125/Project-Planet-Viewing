using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : MonoBehaviour
{
    public enum PageType { SaveAndLoad, Config, Help, Planet, Test}
    public PageType pageType;

    private const string OPEN = "Open";
    private const string CLOSE = "Close";
    public Animator animator;
    public virtual void Open()
    {
        animator.SetTrigger(OPEN);
    }

    public virtual void Close(bool closeAllMenus = false)
    {
        animator.SetTrigger(CLOSE);

        if (closeAllMenus)
            MenuManager.Instance.CloseRoot();
    }
}
