using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
	[SerializeField] CanvasGroup[] elements;

	void Start()
    {
		GameManager.Instance.startScreen = this.gameObject;
        hideGameElements(true);
	}

	public void hideGameElements(bool hidden)
    {
		if (hidden)
        {
			foreach (CanvasGroup element in elements)
            {
                element.alpha = 0;
            }
        }
        else
        {
            foreach (CanvasGroup element in elements)
            {
                element.alpha = 1;
            }
        }
    }

}
