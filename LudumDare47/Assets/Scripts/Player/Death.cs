using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private GameObject crashmenu;

    private void Awake()
    {
        crashmenu = GameObject.FindGameObjectWithTag("CrashMenu");
        crashmenu.SetActive(false);
    }

    public void PlayerDeath(string deathText)
    {
        crashmenu.SetActive(true);
        GameObject.FindGameObjectWithTag("CrashText").GetComponent<Text>().text = deathText;
        gameObject.SetActive(false);
    }
}
