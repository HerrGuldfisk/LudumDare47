using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private GameObject crashmenu;
    private CanvasGroup canvasGroup;
	private Text[] texts;

    private void Awake()
    {
        crashmenu = GameObject.FindGameObjectWithTag("CrashMenu");
        canvasGroup = crashmenu.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void PlayerDeath(string deathText)
    {
        canvasGroup.alpha = 1;

		texts = crashmenu.GetComponentsInChildren<Text>();

		foreach (Text text in texts)
		{
			if (text.CompareTag("CrashText"))
			{
				text.text = deathText;
			}

			if (text.CompareTag("CollectedResourcesText"))
			{
				text.text = "COLECTED RESOURCES: " + GameManager.Instance.collectedResources;
			}
		}
		// crashmenu.GetComponentsInChildren<Text>().text = deathText;
		// crashmenu.GetComponentInChildren<Text>().text = "COLECTED RESOURCES: " + GameManager.Instance.collectedResources;
		gameObject.SetActive(false);
    }
}
