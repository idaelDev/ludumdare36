using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public CanvasGroup main;
    public CanvasGroup htp;
    public CanvasGroup credits;

    void Start()
    {
        goToMain();
    }

    public void activateAll(bool show)
    {
        activateCanvas(main, show);
        activateCanvas(htp, show);
        activateCanvas(credits, show);
    }

    public void activateCanvas(CanvasGroup c, bool show)
    {
        c.alpha = (show) ? 1 : 0;
        c.blocksRaycasts = show;
        c.interactable = show;
    }

    public void play()
    {
        GameManager.Instance.NextLevel();
    }

    public void goToMain()
    {
        activateAll(false);
        activateCanvas(main, true);
    }

    public void goToCredits()
    {
        activateAll(false);
        activateCanvas(credits, true);
    }

    public void goToHTP()
    {
        activateAll(false);
        activateCanvas(htp, true);
    }

}
