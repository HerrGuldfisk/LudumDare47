using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private GameObject crashmenu;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        crashmenu = GameObject.FindGameObjectWithTag("CrashMenu");
        canvasGroup = crashmenu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void PlayerDeath(string deathText)
    {
        canvasGroup.alpha = 1;
        crashmenu.GetComponentInChildren<Text>().text = deathText;
        gameObject.SetActive(false);
    }
}
